using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FS.Core.Interfaces;
using FS.Core.Models;
using FS.Infrastructure.Data;
using FS.Api.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FS.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FavoriteTeamsController : Controller
    {
        private readonly IUsersRepository<User> usersRepository;
        private readonly IFavoriteTeamsRepository favoriteTeamsRepository;
        private readonly ITeamsRepository teamsRepository;

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

            int teamId = favoriteTeamDto.TeamId;
            User userFromRepository = usersRepository.FindByName(HttpContext.User.Identity.Name);

            var favoriteTeamToSave = new FavoriteTeam
            {
                User = userFromRepository,
                Team = teamsRepository.Get().FirstOrDefault(team => team.Code == teamId)
                       ?? new Team { Code = teamId }
            };

            if (favoriteTeamsRepository.Get().Contains(favoriteTeamToSave))
            {
                return Ok();
            }

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

            int teamId = favoriteTeamDto.TeamId;
            User userFromRepository = usersRepository.FindByName(HttpContext.User.Identity.Name);
            Team team = teamsRepository.Get().FirstOrDefault(t => t.Code == teamId);

            if (team == null)
            {
                return BadRequest();
            }

            var teamToRemove = new FavoriteTeam
            {
                User = userFromRepository,
                Team = team
            };

            favoriteTeamsRepository.Remove(teamToRemove);

            return Ok();
        }
    }
}