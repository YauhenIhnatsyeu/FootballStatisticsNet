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
        private readonly ILeagueTablesRepository leagueTablesRepository;
        private readonly ILeagueTeamsRepository leagueTeamsRepository;
        private readonly ITeamsRepository teamsRepository;

        public FootballController(
            IMapper mapper,
            ILeagueTablesRepository leagueTablesRepository,
            ILeagueTeamsRepository leagueTeamsRepository,
            ITeamsRepository teamsRepository)
        {
            this.mapper = mapper;
            this.leagueTablesRepository = leagueTablesRepository;
            this.leagueTeamsRepository = leagueTeamsRepository;
            this.teamsRepository = teamsRepository;
        }

        [Route("league/{code}/tables")]
        public IActionResult GetLeagueTables(int code)
        {
            ICollection<LeagueTable> leagueTables = leagueTablesRepository.GetByCode(code);

            return leagueTables != null
                ? (IActionResult)Json(
                    mapper.Map<ICollection<LeagueTable>, ICollection<LeagueTableDTO>>(leagueTables))
                : BadRequest();
        }

        [Route("league/{code}/teams")]
        public IActionResult GetLeagueTeams(int code)
        {
            ICollection<Team> leagueTeams = leagueTeamsRepository.GetByCode(code);

            return leagueTeams != null
                ? (IActionResult)Json(
                    mapper.Map<ICollection<Team>, ICollection<TeamDTO>>(leagueTeams))
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