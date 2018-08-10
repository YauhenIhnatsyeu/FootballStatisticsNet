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
        private readonly IMapper mapper;
        private readonly ILeaguesRepository leaguesRepository;
        private readonly ITeamsRepository teamsRepository;

        public FootballController(
            IMapper mapper,
            ILeaguesRepository leaguesRepository,
            ITeamsRepository teamsRepository)
        {
            this.mapper = mapper;
            this.leaguesRepository = leaguesRepository;
            this.teamsRepository = teamsRepository;
        }

        [Route("leagues/{code}")]
        public IActionResult GetLeague(int code)
        {
            ICollection<LeagueTeam> league = leaguesRepository.GetByCode(code);

            return league != null
                ? (IActionResult)Json(
                    mapper.Map<ICollection<LeagueTeam>, ICollection<LeagueTeamDTO>>(league))
                : BadRequest();
        }

        [Route("teams/{code}")]
        public IActionResult GetTeam(int code)
        {
            Team team = teamsRepository.GetByCode(code);

            return team != null
                ? (IActionResult) Json(mapper.Map<Team, TeamDTO>(team))
                : BadRequest();
        }
    }
}