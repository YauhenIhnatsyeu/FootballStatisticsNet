using System.Threading.Tasks;
using AutoMapper;
using FS.Core.Interfaces;
using FS.Core.Models;
using FS.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FS.Controllers
{
    public class UsersController : Controller
    {
        private readonly ICloudinaryService cloudinaryService;
        private readonly IMapper mapper;
        private readonly IUsersRepository<User> usersRepository;
        private readonly IJWTService jwtService;

        public UsersController(
            IMapper mapper,
            ICloudinaryService cloudinaryService,
            IUsersRepository<User> usersRepository,
            IJWTService jwtService)
        {
            this.mapper = mapper;
            this.cloudinaryService = cloudinaryService;
            this.usersRepository = usersRepository;
            this.jwtService = jwtService;
        }

        [HttpPost]
        [Route("/users/register")]
        public IActionResult Register([FromBody] UserDTO userDtoParam)
        {
            if (userDtoParam == null)
            {
                return BadRequest();
            }

            if (!cloudinaryService.Exists(userDtoParam.AvatarId, out var getAvatarResult))
            {
                return BadRequest();
            }

            var userDto = userDtoParam;

            userDto.AvatarUrl = getAvatarResult.SecureUrl;

            var user = mapper.Map<User>(userDto);

            return usersRepository.Create(user, userDto.Password)
                ? (IActionResult)Ok()
                : BadRequest();
        }

        [HttpPost]
        [Route("/users/login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDto)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            if (userDto == null)
            {
                return BadRequest();
            }

            User user = mapper.Map<User>(userDto);

            if (!usersRepository.SignIn(user, userDto.Password))
            {
                return BadRequest();
            }

            User userFromDb = usersRepository.FindByName(user.UserName);

            return Ok(new
            {
                User = new { Name = userFromDb.UserName, userFromDb?.AvatarUrl },
                Token = jwtService.GetToken(userFromDb)
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