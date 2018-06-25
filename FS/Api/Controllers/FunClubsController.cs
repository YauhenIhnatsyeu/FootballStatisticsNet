using FS.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FS.Controllers
{
    public class FunClubsController : Controller
    {
        //private readonly UsersContext context;
        //private readonly UserManager<User> userManager;

        //public FunClubsController(UsersContext context, UserManager<User> userManager)
        //{
        //    this.context = context;
        //    this.userManager = userManager;
        //}

        [HttpPost]
        [Route("/funclubs/create")]
        public IActionResult Create([FromBody] FunClubDTO funClubDto)
        {
            return Ok();
        }
    }
}