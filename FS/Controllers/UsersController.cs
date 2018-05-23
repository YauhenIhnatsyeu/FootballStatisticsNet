using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FS.Dtos;
using FS.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FS.Controllers
{
    public class UsersController : Controller
    {
        public UsersController(
            UsersContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        private UsersContext context;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private IMapper mapper;

        [HttpPost]
        [Route("/users/register")]
        public async Task<IActionResult> Register([FromBody]UserDto userDto)
        {
            var user = mapper.Map<User>(userDto);
            var result = await userManager.CreateAsync(user, userDto.Password);
            return result.Succeeded
                ? (IActionResult)Ok()
                : BadRequest();
        }

        [HttpPost]
        [Route("/users/login")]
        public async Task<IActionResult> Login([FromBody]UserDto userDto)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            var user = mapper.Map<User>(userDto);
            var result = await signInManager.PasswordSignInAsync(user.UserName, userDto.Password, false, false);
            
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            var claims = new[] 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            };

            var configuration = ConfigurationContainer.Configuration;
            var secretKey = configuration["Jwt:SecretKey"];

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                 issuer: configuration["Jwt:Issuer"],
                 audience: configuration["Jwt:Audience"],
                 claims: claims,
                 expires: DateTime.Now.AddMonths(3),
                 signingCredentials: signingCredentials
            );
            
            return Ok(new {
                user = new {
                    Name = user.UserName,
                },
                token = new JwtSecurityTokenHandler().WriteToken(token),
            });
        }

        [Route("/users/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("/private")]
        public IActionResult Private() {
            return Content("You're there, man");
        }
    }
}
