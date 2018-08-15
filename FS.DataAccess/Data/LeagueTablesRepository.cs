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

            ICollection<LeagueTable> leagueTables = cache.GetOrCreate(key, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                return leagueTablesService.GetByCode(code);
            });

            return leagueTables;
        }
    }
}