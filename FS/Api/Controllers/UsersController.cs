using System.Threading.Tasks;
using AutoMapper;
using FS.Core.Enums;
using FS.Core.Interfaces;
using FS.Core.Models;
using FS.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FS.Api.Controllers
{
    public class UsersController : Controller
    {
        private readonly ICloudinaryService cloudinaryService;
        private readonly IJWTService jwtService;
        private readonly IMapper mapper;
        private readonly IUsersRepository<User> usersRepository;

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
        [Route("/api/users/register")]
        public IActionResult Register([FromBody] UserDTO userDtoParam)
        {
            if (userDtoParam == null)
            {
                return BadRequest();
            }

            UserDTO userDto = userDtoParam;

            AvatarState avatarState = userDtoParam.AvatarId == null
                ? AvatarState.NotRequested
                : AvatarState.Requested;

            if (avatarState == AvatarState.Requested)
            {
                if (!cloudinaryService.Exists(userDtoParam.AvatarId, out var getAvatarResult))
                {
                    return BadRequest();
                }

                userDto.AvatarUrl = getAvatarResult.SecureUrl;
            }

            User user = mapper.Map<User>(userDto);

            return usersRepository.Create(user, userDto.Password)
                ? (IActionResult) Ok()
                : BadRequest();
        }

        [HttpPost]
        [Route("/api/users/login")]
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
                User = new {Name = userFromDb.UserName, userFromDb?.AvatarUrl},
                Token = jwtService.GetToken(userFromDb)
            });
        }

        [Route("/api/users/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return Ok();
        }
    }
}