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
        private readonly ITeamsRepository teamsRepository;
        private readonly IUsersFunClubsRepository usersFunClubsRepository;
        private readonly IUsersRepository<User> usersRepository;

        public FunClubsController(
            ITeamsRepository teamsRepository,
            IFunClubsRepository funClubsRepository,
            IUsersFunClubsRepository usersFunClubsRepository,
            IUsersRepository<User> usersRepository)
        {
            this.teamsRepository = teamsRepository;
            this.funClubsRepository = funClubsRepository;
            this.usersFunClubsRepository = usersFunClubsRepository;
            this.usersRepository = usersRepository;
        }

        [HttpPost]
        [Route("/api/funclubs/create")]
        public IActionResult Create([FromBody] FunClubDTO funClubDto)
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
    }
}