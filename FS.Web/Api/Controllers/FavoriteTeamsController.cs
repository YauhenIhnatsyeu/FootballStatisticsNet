using System.Collections.Generic;
using System.Linq;
using FS.Api.DTOs;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FS.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FavoriteTeamsController : Controller
    {
        private readonly IFavoriteTeamsRepository favoriteTeamsRepository;
        private readonly ITeamsRepository teamsRepository;
        private readonly IUsersRepository<User> usersRepository;

        public FavoriteTeamsController(
            IUsersRepository<User> usersRepository,
            IFavoriteTeamsRepository favoriteTeamsRepository,
            ITeamsRepository teamsRepository)
        {
            this.usersRepository = usersRepository;
            this.favoriteTeamsRepository = favoriteTeamsRepository;
            this.teamsRepository = teamsRepository;
        }

        [HttpGet]
        [Route("/api/teams/get")]
        public IActionResult GetTeams()
        {
            User userFromRepository = usersRepository.FindByName(HttpContext.User.Identity.Name);
            IEnumerable<int> teamIds = favoriteTeamsRepository.Get()
                .Where(fv => fv.User == userFromRepository)
                .Select(fv => fv.Team.Code);

            return Ok(new
            {
                TeamIds = teamIds
            });
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("/api/teams/add")]
        public IActionResult AddTeam([FromBody] FavoriteTeamDTO favoriteTeamDto)
        {
            if (favoriteTeamDto == null)
            {
                return BadRequest();
            }

            var teamToSave = new Team {Code = favoriteTeamDto.TeamId};
            teamsRepository.Add(teamToSave);

            User userFromRepository = usersRepository.FindByName(HttpContext.User.Identity.Name);

            var favoriteTeamToSave = new FavoriteTeam
            {
                User = userFromRepository,
                Team = teamsRepository.GetByTeam(teamToSave)
            };

            favoriteTeamsRepository.Add(favoriteTeamToSave);

            return Ok();
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("/api/teams/remove")]
        public IActionResult RemoveTeam([FromBody] FavoriteTeamDTO favoriteTeamDto)
        {
            if (favoriteTeamDto == null)
            {
                return BadRequest();
            }

            var team = new Team {Code = favoriteTeamDto.TeamId};

            if (!teamsRepository.Contains(team))
            {
                return BadRequest();
            }

            User userFromRepository = usersRepository.FindByName(HttpContext.User.Identity.Name);

            var favoriteTeamToRemove = new FavoriteTeam
            {
                User = userFromRepository,
                Team = teamsRepository.GetByTeam(team)
            };

            favoriteTeamsRepository.Remove(favoriteTeamToRemove);

            return Ok();
        }
    }
}