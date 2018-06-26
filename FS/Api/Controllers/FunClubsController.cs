using FS.Api.DTOs;
using FS.Core.Models;
using FS.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FS.Api.Controllers
{
    public class FunClubsController : Controller
    {
        private readonly UsersContext context;
        private readonly UserManager<User> userManager;

        public FunClubsController(UsersContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("/api/funclubs/create")]
        public IActionResult Create([FromBody] FunClubDTO funClubDto)
        {
            return Ok();
        }
    }
}