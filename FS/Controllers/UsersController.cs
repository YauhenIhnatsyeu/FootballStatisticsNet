using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FS.Dtos;
using FS.Migrations;
using FS.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;

namespace FS.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersContext context;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        private readonly Cloudinary cloudinary;

        public UsersController(
            UsersContext context,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IMapper mapper)
        {
            this.context = context;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.mapper = mapper;

            var account = new Account("greatdouble", "186989138943984", "UatKlrq8YqYWThmiwtfS_wQzH4o");
            cloudinary = new Cloudinary(account);
            //var uploadParams = new ImageUploadParams {
            //    File = new FileDescription(
            //        @"C:\Users\yauhen.ihnatsyeu\Downloads\60835_new_york_dual_screen_dual_monitor_new_york_cityscape_dual_screen.jpg"
            //        //"profile_picture.jpg",
            //        //new MemoryStream(Encoding.UTF8.GetBytes(userViewModel.ProfilePicture))
            //    )
            //};
            //cloudinary.Upload(uploadParams);
        }

        [HttpPost]
        [Route("/users/avatar")]
        public IActionResult UploadProfilePicture() {
            if (HttpContext.Request.Form?.Files?.Count != 1) return BadRequest();

            var avatar = HttpContext.Request.Form.Files[0];
            var avatarHashCode = avatar.GetHashCode();
            var avatarStream = avatar.OpenReadStream();

            var uploadParams = new ImageUploadParams {
                File = new FileDescription($"avatar-{avatarHashCode}", avatarStream)
            };

            var uploadResult = cloudinary.Upload(uploadParams);

            if (uploadResult.StatusCode != HttpStatusCode.OK) return BadRequest();

            return Ok(new { AvatarId = uploadResult.PublicId });
        }

        [HttpPost]
        [Route("/users/register")]
        public async Task<IActionResult> Register([FromBody] UserViewModel userViewModelParam)
        {

            var getAvatarResult = cloudinary.GetResource(userViewModelParam.AvatarId);

            if (getAvatarResult.StatusCode != HttpStatusCode.OK) return BadRequest();

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

            var user = mapper.Map<User>(userViewModel);
            var result = await signInManager.PasswordSignInAsync(user.UserName, userViewModel.Password, false, false);

            if (!result.Succeeded) return BadRequest();

            var claims = new[] {
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

            return Ok(new {
                User = new {
                    Name = user.UserName,
                    context.Users.Single(u => u.UserName == user.UserName).AvatarUrl,
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("/private")]
        public IActionResult Private()
        {
            return Content("You're there, man");
        }
    }
}