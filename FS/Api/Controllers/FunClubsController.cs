using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FS.Api.DTOs;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FS.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FunClubsController : Controller
    {
        private readonly IFunClubsRepository funClubsRepository;
        private readonly IMapper mapper;
        private readonly ITeamsRepository teamsRepository;
        private readonly IUsersFunClubsRepository usersFunClubsRepository;
        private readonly IUsersRepository<User> usersRepository;

        public FunClubsController(IFunClubsRepository funClubsRepository, IMapper mapper,
            ITeamsRepository teamsRepository, IUsersFunClubsRepository usersFunClubsRepository,
            IUsersRepository<User> usersRepository)
        {
            this.funClubsRepository = funClubsRepository;
            this.mapper = mapper;
            this.teamsRepository = teamsRepository;
            this.usersFunClubsRepository = usersFunClubsRepository;
            this.usersRepository = usersRepository;
        }

        [AllowAnonymous]
        [Route("/api/funclubs/get")]
        public IActionResult Get()
        {
            //IEnumerable<UserToClientDTO> users = usersRepository.Get()
            //    .Select(user => mapper.Map<UserToClientDTO>(user));

            //IEnumerable<FunClubToClientDTO> funClubs = funClubsRepository.Get()
            //    .Select(funClub => mapper.Map<FunClubToClientDTO>(funClub));

            //IEnumerable<IEnumerable<UserFunClubToClientDTO>> funClubs = funClubsRepository.Get()
            //    .Select(funClub => mapper.Map<ICollection<UserFunClub>, IEnumerable<UserFunClubToClientDTO>>(funClub.UsersFunClub));

            return Ok(/*funClubs*/);
        }

        [HttpPost]
        [Route("/api/funclubs/create")]
        public IActionResult Create([FromBody] FunClubToServerDTO funClubDto)
        {
            if (funClubDto == null)
            {
                return BadRequest();
            }

            var teamToSave = new Team {Code = funClubDto.TeamId};
            teamsRepository.Add(teamToSave);

            var funClub = new FunClub
            {
                Name = funClubDto.Name,
                Description = funClubDto.Description,
                AvatarUrl = funClubDto.AvatarUrl,
                Team = teamsRepository.GetByTeam(teamToSave)
            };

            // User-creator
            usersFunClubsRepository.Add(new UserFunClub
            {
                FunClub = funClub,
                User = usersRepository.FindByName(HttpContext.User.Identity.Name),
                UserIsCreator = true
            });

            // Other users
            foreach (string userId in funClubDto.UsersIds)
            {
                usersFunClubsRepository.Add(new UserFunClub
                {
                    FunClub = funClub,
                    User = usersRepository.FindById(userId),
                    UserIsCreator = false
                });
            }

            return Ok();
        }

        [HttpPost]
        [Route("/api/funclubs/adduser")]
        public IActionResult AddUser([FromBody] UserFunClubToServerDTO userFunClubDto)
        {
            if (userFunClubDto == null)
            {
                return BadRequest();
            }

            usersFunClubsRepository.Add(new UserFunClub
            {
                User = usersRepository.FindById(userFunClubDto.UserId),
                FunClub = funClubsRepository.FindById(userFunClubDto.FunClubId),
                UserIsCreator = false
            });

            return Ok();
        }

        [HttpPost]
        [Route("/api/funclubs/removeuser")]
        public IActionResult RemoveUser([FromBody] UserFunClubToServerDTO userFunClubDto)
        {
            if (userFunClubDto == null)
            {
                return BadRequest();
            }

            usersFunClubsRepository.Remove(new UserFunClub
            {
                User = usersRepository.FindById(userFunClubDto.UserId),
                FunClub = funClubsRepository.FindById(userFunClubDto.FunClubId),
            });

            return Ok();
        }
    }
}