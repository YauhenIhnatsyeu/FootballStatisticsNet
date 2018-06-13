using System;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FS.Dtos;
using FS.Helpers;
using FS.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FS.Controllers
{
    public class UsersController : Controller
    {
        private readonly Cloudinary cloudinary;
        private readonly IMapper mapper;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public UsersController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IMapper mapper)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.mapper = mapper;

            var configuration = ConfigurationContainer.Configuration;
            
            cloudinary = CloudinaryHelper.GetCloudinary(
                configuration["Cloudinary:Cloud"],
                configuration["Cloudinary:ApiKey"],
                configuration["Cloudinary:ApiSecret"]
            );
        }

        [HttpPost]
        [Route("/users/avatar")]
        public IActionResult UploadProfilePicture()
        {
            if (HttpContext.Request.Form?.Files?.Count != 1) return BadRequest();

            var avatar = HttpContext.Request.Form.Files[0];
            var avatarHashCode = avatar.GetHashCode();
            var avatarStream = avatar.OpenReadStream();

            var uploadResult = CloudinaryHelper.UploadFile(cloudinary, $"avatar-{avatarHashCode}", avatarStream);

            if (uploadResult.StatusCode != HttpStatusCode.OK) return BadRequest();

            return Ok(new {AvatarId = uploadResult.PublicId});
        }

        [HttpPost]
        [Route("/users/register")]
        public async Task<IActionResult> Register([FromBody] UserViewModel userViewModelParam)
        {
            if (userViewModelParam == null) return BadRequest();

            if (!CloudinaryHelper.Exists(cloudinary, userViewModelParam.AvatarId, out var getAvatarResult))
            {
                return BadRequest();
            }

            var userViewModel = userViewModelParam;

            userViewModel.AvatarUrl = getAvatarResult.Url;

            var user = mapper.Map<User>(userViewModel);
            var result = await userManager.CreateAsync(user, userViewModel.Password);

            return result.Succeeded
                ? (IActionResult) Ok()
                : BadRequest();
        }

        [HttpPost]
        [Route("/users/login")]
        public async Task<IActionResult> Login([FromBody] UserViewModel userViewModel)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            if (userViewModel == null) return BadRequest();

            var user = mapper.Map<User>(userViewModel);
            var result = await signInManager.PasswordSignInAsync(user.UserName, userViewModel.Password, false, false);

            if (!result.Succeeded) return BadRequest();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var configuration = ConfigurationContainer.Configuration;
            var secretKey = configuration["Jwt:SecretKey"];

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMonths(3),
                signingCredentials: signingCredentials
            );

            var dbUser = await userManager.FindByNameAsync(user.UserName);

            return Ok(new
            {
                User = new
                {
                    Name = user.UserName,
                    dbUser?.AvatarUrl
                },
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

        [Route("/users/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return Ok();
        }
    }
}