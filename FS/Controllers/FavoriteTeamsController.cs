using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FS.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FS.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FavoriteTeamsController : Controller
    {
        private readonly UsersContext context;
        private readonly UserManager<User> userManager;

        public FavoriteTeamsController(UsersContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("/teams/get")]
        public async Task<IActionResult> GetTeams()
        {
            User dbUser = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var teamIds = new List<int>();
            IEnumerable<FavoriteTeam> favoriteTeams = context.FavoriteTeams
                .Where(item => item.User == dbUser);

            foreach (var item in favoriteTeams)
            {
                context.Entry(item).Reference(favoriteTeam => favoriteTeam.Team).Load();
                teamIds.Add(item.Team.Code);
            }

            return Ok(new
            {
                TeamIds = teamIds
            });
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("/teams/add")]
        public async Task<IActionResult> AddTeam([FromBody] FavoriteTeamViewModel favoriteTeamViewModel)
        {
            if (favoriteTeamViewModel == null)
            {
                return BadRequest();
            }

            int teamId = favoriteTeamViewModel.TeamId;
            User dbUser = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            var favoriteTeamToSave = new FavoriteTeam
            {
                User = dbUser,
                Team = context.Teams.Single(team => team.Code == teamId)
                       ?? new Team {Code = teamId}
            };

            if (context.FavoriteTeams.Contains(favoriteTeamToSave))
            {
                return Ok();
            }

            context.FavoriteTeams.Add(favoriteTeamToSave);
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("/teams/remove")]
        public async Task<IActionResult> RemoveTeam([FromBody] FavoriteTeamViewModel favoriteTeamViewModel)
        {
            if (favoriteTeamViewModel == null)
            {
                return BadRequest();
            }

            int teamId = favoriteTeamViewModel.TeamId;
            User dbUser = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            Team team = context.Teams.Single(t => t.Code == teamId);

            if (team == null)
            {
                return BadRequest();
            }

            var teamToRemove = new FavoriteTeam
            {
                User = dbUser,
                Team = team
            };

            context.FavoriteTeams.Remove(teamToRemove);
            context.SaveChanges();

            return Ok();
        }
    }
}