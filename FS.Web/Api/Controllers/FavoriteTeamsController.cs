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
    [Route("api/favorite-teams")]
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
        [Route("add")]
        public IActionResult AddTeam([FromBody] FavoriteTeamDTO favoriteTeamDto)
        {
            if (favoriteTeamDto == null)
            {
                return BadRequest();
            }

            User loggedInUser = usersRepository.GetLoggedInUser();

            if (loggedInUser == null)
            {
                return BadRequest();
            }

            Team team = teamsRepository.GetByCode(favoriteTeamDto.TeamId);

            if (team == null)
            {
                return BadRequest();
            }

            if (favoriteTeamsRepository.GetByUserAndTeam(loggedInUser, team) == null)
            {
                favoriteTeamsRepository.Add(new FavoriteTeam {User = loggedInUser, Team = team});
            }

            return Ok();
        }

        [HttpDelete]
        [Route("remove")]
        public IActionResult RemoveTeam([FromBody] FavoriteTeamDTO favoriteTeamDto)
        {
            if (favoriteTeamDto == null)
            {
                return BadRequest();
            }

            User loggedInUser = usersRepository.GetLoggedInUser();

            if (loggedInUser == null)
            {
                return BadRequest();
            }

            Team team = teamsRepository.GetByCode(favoriteTeamDto.TeamId);

            if (team == null)
            {
                return BadRequest();
            }

            var favoriteTeam = favoriteTeamsRepository.GetByUserAndTeam(loggedInUser, team);

            if (favoriteTeam != null)
            {
                favoriteTeamsRepository.Remove(favoriteTeam);
            }

            return Ok();
        }
    }
}