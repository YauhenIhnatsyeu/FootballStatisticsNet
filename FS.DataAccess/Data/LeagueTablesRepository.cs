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
    public class LeagueTablesRepository : ILeagueTablesRepository
    {
        private readonly ILeagueTablesService leagueTablesService;
        private readonly IMemoryCache cache;

        public LeagueTablesRepository(ILeagueTablesService leagueTablesService, IMemoryCache memoryCache)
        {
            this.leagueTablesService = leagueTablesService;
            cache = memoryCache;
        }

        public ICollection<LeagueTable> GetByCode(int code)
        {
            string key = $"league-table_{code}";

            if (cache.TryGetValue(key, out ICollection<LeagueTable> leagueTables))
            {
                return leagueTables;
            }

            leagueTables = leagueTablesService.GetByCode(code);
            cache.Set(key, leagueTables, TimeSpan.FromMinutes(5));

            return leagueTables;
        }
    }
}