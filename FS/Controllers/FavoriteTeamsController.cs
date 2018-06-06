using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FS.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace FS_Server.Controllers
{
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("/teams/get")]
        public async Task<IActionResult> GetTeams() {
            User dbUser = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var teamIds = new List<int>();

            context.FavoriteTeamsLists
                .Where(item => item.Id == dbUser.Id)
                .ToList()
                .ForEach(item => teamIds.Add(item.TeamId));

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
            if (favoriteTeamViewModel == null) return BadRequest();

            int teamId = favoriteTeamViewModel.TeamId;

            User dbUser = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            var teamToSave = new TFavoriteTeamsList
            {
                Id = dbUser.Id,
                TeamId = teamId
            };

            if (await context.FavoriteTeamsLists.FindAsync(teamToSave) != null)
            {
                return Ok();
            }

            context.FavoriteTeamsLists.Add(teamToSave);
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("/teams/remove")]
        public async Task<IActionResult> RemoveTeam([FromBody] FavoriteTeamViewModel favoriteTeamViewModel) {
            if (favoriteTeamViewModel == null) return BadRequest();

            int teamId = favoriteTeamViewModel.TeamId;

            User dbUser = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            var teamToRemove = new TFavoriteTeamsList {
                Id = dbUser.Id,
                TeamId = teamId
            };

            if (context.FavoriteTeamsLists.Find(teamToRemove) == null) {
                return Ok();
            }

            context.FavoriteTeamsLists.Remove(teamToRemove);
            context.SaveChanges();

            return Ok();
        }
    }
}