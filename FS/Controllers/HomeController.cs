using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FS.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(
            UsersContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager
        ) {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        private UsersContext context;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        [Route("{*url}")]
        public IActionResult Index() {
            return View();
        }

        //[Route("create")]
        //[Route("{*url}")]
        //public async Task<IActionResult> CreateUserAsync() {
        //    var result = await userManager.CreateAsync(new User {
        //        UserName = "1Brian",
        //        Email = "@@@",
        //        BirthDate = new DateTime(2000, 1, 1),
        //    }, "password");

        //    return Content(result.Succeeded ? "OK" : "NOT OK");
        //}
    }
}