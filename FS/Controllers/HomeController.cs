using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using FS.Dtos;

namespace FS.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(
            UsersContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper) {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        private UsersContext context;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private IMapper mapper;

        [HttpGet]
        [Route("{*url}")]
        public IActionResult Index() {
            return View();
        }

        // [AllowAnonymous]
        [HttpPost]
        [Route("/users/register")]
        public async Task<IActionResult> Register([FromBody]UserDto userDto) {
            var user = mapper.Map<User>(userDto);
            var result = await userManager.CreateAsync(user, userDto.Password);
            return result.Succeeded ? (IActionResult) Ok() : BadRequest();
        }
    }
}