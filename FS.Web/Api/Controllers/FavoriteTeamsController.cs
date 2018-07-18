using System.Collections.Generic;
using System.Linq;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;
using FS.Web.Api.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FS.Web.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/teams")]
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
        [Route("get")]
        public IActionResult GetTeams()
        {
            User loggedInUser = usersRepository.GetLoggedInUser();
            IEnumerable<int> teamIds = favoriteTeamsRepository.Get()
                .Where(fv => fv.User == loggedInUser)
                .Select(fv => fv.Team.Code);

            return Ok(new
            {
                TeamIds = teamIds
            });
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("add")]
        public IActionResult AddTeam([FromBody] FavoriteTeamDTO favoriteTeamDto)
        {
            if (favoriteTeamDto == null)
            {
                return BadRequest();
            }

            var teamToSave = new Team {Code = favoriteTeamDto.TeamId};
            teamsRepository.Add(teamToSave);

            User loggedInUser = usersRepository.GetLoggedInUser();

            var favoriteTeamToSave = new FavoriteTeam
            {
                User = loggedInUser,
                Team = teamsRepository.GetByTeam(teamToSave)
            };

            favoriteTeamsRepository.Add(favoriteTeamToSave);

            return Ok();
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("remove")]
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

            User loggedInUser = usersRepository.GetLoggedInUser();

            var favoriteTeamToRemove = new FavoriteTeam
            {
                User = loggedInUser,
                Team = teamsRepository.GetByTeam(team)
            };

            favoriteTeamsRepository.Remove(favoriteTeamToRemove);

            return Ok();
        }
    }
}