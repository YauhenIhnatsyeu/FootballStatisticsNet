using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FS.Dtos;
using FS.Interfaces;
using FS.Models;
using FS.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FS.Controllers
{
    public class UsersController : Controller
    {
        private readonly ICloudinaryService cloudinaryService;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UsersController(
            IMapper mapper,
            IUserService userService,
            IConfiguration configuration,
            ICloudinaryService cloudinaryService)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpPost]
        [Route("/users/register")]
        public async Task<IActionResult> Register([FromBody] UserViewModel userViewModelParam)
        {
            if (userViewModelParam == null)
            {
                return BadRequest();
            }

            if (!cloudinaryService.Exists(userViewModelParam.AvatarId, out var getAvatarResult))
            {
                return BadRequest();
            }

            var userViewModel = userViewModelParam;

            userViewModel.AvatarUrl = getAvatarResult.SecureUrl;

            var user = mapper.Map<User>(userViewModel);

            return await userService.CreateAsync(user, userViewModel.Password)
                ? (IActionResult) Ok()
                : BadRequest();
        }

        [HttpPost]
        [Route("/users/login")]
        public async Task<IActionResult> Login([FromBody] UserViewModel userViewModel)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            if (userViewModel == null)
            {
                return BadRequest();
            }

            User user = mapper.Map<User>(userViewModel);

            if (!await userService.SignInAsync(user.UserName, userViewModel.Password, out string token))
            {
                return BadRequest();
            }

            User dbUser = await userService.FindByNameAsync(user.UserName);

            return Ok(new
            {
                User = new {Name = user.UserName, dbUser?.AvatarUrl},
                Token = token
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