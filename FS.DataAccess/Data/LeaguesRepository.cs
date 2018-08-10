using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;
using FS.Core.Helpers;
using FS.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace FS.DataAccess.Data
{
    public class LeaguesRepository : ILeaguesRepository
    {
        private readonly ILeaguesService leaguesService;
        private readonly IMemoryCache cache;

        public LeaguesRepository(ILeaguesService leaguesService, IMemoryCache memoryCache)
        {
            this.leaguesService = leaguesService;
            cache = memoryCache;
        }

        public ICollection<LeagueTeam> GetByCode(int code)
        {
            string key = $"league_{code}";

            if (cache.TryGetValue(key, out ICollection<LeagueTeam> league))
            {
                return league;
            }

            league = leaguesService.GetByCode(code);
            cache.Set(key, league, TimeSpan.FromMinutes(5));

            return league;
        }
    }
}