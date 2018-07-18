using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FS.Core.Interfaces.Repositories;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using FS.Web.Api.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FS.Web.Api.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IAvatarsRepository avatarsRepository;
        private readonly IJWTService jwtService;
        private readonly IMapper mapper;
        private readonly IUsersRepository<User> usersRepository;

        public UsersController(
            IMapper mapper,
            IAvatarsRepository avatarsRepository,
            IUsersRepository<User> usersRepository,
            IJWTService jwtService)
        {
            this.mapper = mapper;
            this.avatarsRepository = avatarsRepository;
            this.usersRepository = usersRepository;
            this.jwtService = jwtService;
        }

        [Route("get")]
        public IActionResult Get()
        {
            IEnumerable<UserToClientDTO> users =
                mapper.Map<IReadOnlyList<User>, IEnumerable<UserToClientDTO>>(usersRepository.Get());
            return Ok(users);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] UserToServerDTO userDtoParam)
        {
            if (userDtoParam == null)
            {
                return BadRequest();
            }

            UserToServerDTO userDto = userDtoParam;

            if (userDtoParam.AvatarId != null)
            {
                string avatarUrl = avatarsRepository.Get(userDtoParam.AvatarId);

                if (avatarUrl == null)
                {
                    return BadRequest();
                }

                userDto.AvatarUrl = avatarUrl;
            }

            User user = mapper.Map<User>(userDto);

            return usersRepository.Create(user, userDto.Password)
                ? (IActionResult) Ok()
                : BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserToServerDTO userToServerDto)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            if (userToServerDto == null)
            {
                return BadRequest();
            }

            User user = mapper.Map<User>(userToServerDto);

            User loggedInUser = usersRepository.SignIn(user, userToServerDto.Password);

            if (loggedInUser == null)
            {
                return BadRequest();
            }

            UserToClientDTO userToClientDto = mapper.Map<UserToClientDTO>(loggedInUser);

            return Ok(new
            {
                User = userToClientDto,
                Token = jwtService.GetToken(loggedInUser)
            });
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return Ok();
        }
    }
}