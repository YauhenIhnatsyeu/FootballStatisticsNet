using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FS.Core.Enums;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;
using FS.Web.Api.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FS.Web.Api.Controllers
{
    [Route("api/football")]
    public class FootballController : Controller
    {
        private readonly ITeamsRepository teamsRepository;

        public FootballController(ITeamsRepository teamsRepository)
        {
            this.teamsRepository = teamsRepository;
        }

        [Route("teams/{code}")]
        public IActionResult GetTeam(int code)
        {
            Team team = teamsRepository.GetByCode(code);

            return team != null
                ? (IActionResult) Json(team)
                : BadRequest();
        }
    }
}