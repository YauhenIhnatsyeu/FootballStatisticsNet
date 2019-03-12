using System;
using System.Collections.Generic;
using System.Linq;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;
using Microsoft.Extensions.Caching.Memory;

namespace FS.DataAccess.Data
{
    public class LeagueTeamsRepository : ILeagueTeamsRepository
    {
        private readonly IMemoryCache cache;
        private readonly UsersContext context;
        private readonly ILeagueTeamsService leagueTeamsService;

        public LeagueTeamsRepository(ILeagueTeamsService leagueTeamsService, UsersContext context, IMemoryCache cache)
        {
            this.leagueTeamsService = leagueTeamsService;
            this.context = context;
            this.cache = cache;
        }

        public ICollection<Team> GetByCode(int code/*, bool forInitialization = false*/)
        {

            string key = $"league-teams_{code}";

            ICollection<Team> leagueTeams = cache.GetOrCreate(key, entry =>
            {
                // if (forInitialization) {
                //     entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                //     return leagueTeamsService.GetByCode(code);
                // }

                return context.Teams.Where(t => t.LeagueTable.Any(lt => lt.Code == code)).ToList();
            });

            return leagueTeams;
        }
    }
}