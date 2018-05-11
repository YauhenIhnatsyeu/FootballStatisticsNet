using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FS.Dtos;
using FS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FS.Controllers
{
    public class UsersController : Controller {
        public UsersController(
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

        // [AllowAnonymous]
        [HttpPost]
        [Route("/users/register")]
        public async Task<IActionResult> Register([FromBody]UserDto userDto) {
            var user = mapper.Map<User>(userDto);
            var result = await userManager.CreateAsync(user, userDto.Password);
            return result.Succeeded
                ? (IActionResult)Ok()
                : BadRequest();
        }
    }
}