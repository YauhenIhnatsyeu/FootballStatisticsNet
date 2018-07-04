using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FS.Api.DTOs;
using FS.Core.Interfaces.Repositories;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FS.Api.Controllers
{
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

        [Route("/api/users/get")]
        public IActionResult Get()
        {
            IEnumerable<UserToClientDTO> users = usersRepository.Get()
                .Select(user => mapper.Map<UserToClientDTO>(user));
            return Ok(users);
        }

        [HttpPost]
        [Route("/api/users/register")]
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
        [Route("/api/users/login")]
        public async Task<IActionResult> Login([FromBody] UserToServerDTO userToServerDto)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            if (userToServerDto == null)
            {
                return BadRequest();
            }

            User user = mapper.Map<User>(userToServerDto);

            if (!usersRepository.SignIn(user, userToServerDto.Password))
            {
                return BadRequest();
            }

            User userFromRepository = usersRepository.FindByName(user.UserName);
            UserToClientDTO userToClientDto = mapper.Map<UserToClientDTO>(userFromRepository);

            return Ok(new
            {
                User = userToClientDto,
                Token = jwtService.GetToken(userFromRepository)
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