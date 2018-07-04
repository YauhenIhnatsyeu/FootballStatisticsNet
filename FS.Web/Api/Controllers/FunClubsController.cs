using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using FS.Core.Enums;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;
using FS.Web.Api.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FS.Web.Api.Controllers
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
            IEnumerable<FunClubToClientDTO> funClubs =
                mapper.Map<IReadOnlyList<FunClub>, IEnumerable<FunClubToClientDTO>>(funClubsRepository.Get());

            return Ok(funClubs);
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
                UserIsCreator = true,
                MemberStatus = MemberStatus.In
            });

            // Other users
            foreach (string userId in funClubDto.UsersIds)
            {
                usersFunClubsRepository.Add(new UserFunClub
                {
                    FunClub = funClub,
                    User = usersRepository.FindById(userId),
                    UserIsCreator = false,
                    MemberStatus = MemberStatus.In
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
                FunClub = funClubsRepository.FindById(userFunClubDto.FunClubId)
            });

            return Ok();
        }
    }
}