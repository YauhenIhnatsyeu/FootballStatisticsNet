using System;
using System.Collections.Generic;
using FS.Core.Interfaces.Repositories;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using Microsoft.Extensions.Caching.Memory;

namespace FS.DataAccess.Data
{
    public class LeagueTablesRepository : ILeagueTablesRepository
    {
        private readonly IMemoryCache cache;
        private readonly ILeagueTablesService leagueTablesService;

        public LeagueTablesRepository(ILeagueTablesService leagueTablesService, IMemoryCache memoryCache)
        {
            this.leagueTablesService = leagueTablesService;
            cache = memoryCache;
        }

        public ICollection<LeagueTable> GetByCode(int code)
        {
            string key = $"league-tables_{code}";

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