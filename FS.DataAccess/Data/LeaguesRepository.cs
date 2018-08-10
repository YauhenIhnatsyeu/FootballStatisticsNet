using System.Collections.Generic;
using System.Linq;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;
using FS.Core.Helpers;
using FS.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace FS.DataAccess.Data
{
    public class LeaguesRepository : ILeaguesRepository
    {
        private readonly ILeaguesService leaguesService;

        public LeaguesRepository(UsersContext context, ILeaguesService leaguesService)
        {
            this.leaguesService = leaguesService;
        }

        public ICollection<LeagueTeam> GetByCode(int code)
        {
            return leaguesService.GetByCode(code);
        }
    }
}