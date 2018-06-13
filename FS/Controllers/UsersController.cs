using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using FS.Dtos;
using FS.Helpers;
using FS.Interfaces;
using FS.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FS.Controllers
{
    public class UsersController : Controller
    {
        private readonly Cloudinary cloudinary;
        private readonly IMapper mapper;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;

        public UsersController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IMapper mapper,
            IUserService userService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.mapper = mapper;
            this.userService = userService;

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
                return BadRequest();

            var userViewModel = userViewModelParam;

            userViewModel.AvatarUrl = getAvatarResult.Url;

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

            if (userViewModel == null) return BadRequest();

            User user = mapper.Map<User>(userViewModel);

            if (!await userService.SignInAsync(user.UserName, userViewModel.Password, out string token))
                return BadRequest();

            User dbUser = await userManager.FindByNameAsync(user.UserName);

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