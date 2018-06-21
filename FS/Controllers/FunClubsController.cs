using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FS.Models;
using FS.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FS.Controllers
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
        [Route("/funclubs/create")]
        public IActionResult Create([FromBody] FunClubViewModel funClubViewModel)
        {
            return Ok();
        }
    }
}