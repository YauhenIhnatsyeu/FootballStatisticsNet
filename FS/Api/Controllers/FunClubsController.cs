using FS.Api.DTOs;
using FS.Core.Interfaces;
using FS.Core.Models;
using FS.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FS.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FunClubsController : Controller
    {
        private readonly IFunClubsRepository funClubsRepository;
        private readonly IUsersRepository<User> usersRepository;

        public FunClubsController(IFunClubsRepository funClubsRepository, IUsersRepository<User> usersRepository)
        {
            this.funClubsRepository = funClubsRepository;
            this.usersRepository = usersRepository;
        }

        [HttpPost]
        [Route("/api/funclubs/create")]
        public IActionResult Create([FromBody] FunClubDTO funClubDto)
        {
            return Ok();
        }
    }
}