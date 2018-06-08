using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FS.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

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
        public async Task<IActionResult> GetTeams() {
            User dbUser = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var teamIds = new List<int>();

            context.FavoriteTeams
                .Where(item => item.User == dbUser)
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

            var teamToSave = new TFavoriteTeams
            {
                User = dbUser,
                TeamId = teamId
            };

            context.FavoriteTeams.Add(teamToSave);
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

            var teamToRemove = new TFavoriteTeams {
                User = dbUser,
                TeamId = teamId
            };

            context.FavoriteTeams.Remove(teamToRemove);
            context.SaveChanges();

            return Ok();
        }
    }
}