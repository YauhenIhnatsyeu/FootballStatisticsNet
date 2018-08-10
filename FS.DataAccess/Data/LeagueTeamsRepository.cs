using System;
using System.Collections.Generic;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;
using Microsoft.Extensions.Caching.Memory;

namespace FS.DataAccess.Data
{
    public class LeagueTeamsRepository : ILeagueTeamsRepository
    {
        private readonly IMemoryCache cache;
        private readonly ILeagueTeamsService leagueTeamsService;

        public LeagueTeamsRepository(ILeagueTeamsService leagueTeamsService, IMemoryCache cache)
        {
            this.leagueTeamsService = leagueTeamsService;
            this.cache = cache;
        }

        public ICollection<Team> GetByCode(int code)
        {
            string key = $"league-teams_{code}";

            if (cache.TryGetValue(key, out ICollection<Team> leagueTeams))
            {
                return leagueTeams;
            }

            leagueTeams = leagueTeamsService.GetByCode(code);
            cache.Set(key, leagueTeams, TimeSpan.FromMinutes(5));

            return leagueTeams;
        }
    }
}