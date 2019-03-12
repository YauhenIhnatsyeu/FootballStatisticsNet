using System;
using System.Collections.Generic;
using FS.Core.Interfaces.Repositories;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;

namespace FS.DataAccess.Data
{
    public class LeagueTablesRepository : ILeagueTablesRepository
    {
        private readonly UsersContext context;
        private readonly IMemoryCache cache;
        private readonly ILeagueTablesService leagueTablesService;

        public LeagueTablesRepository(UsersContext context, ILeagueTablesService leagueTablesService, IMemoryCache memoryCache)
        {
            this.context = context;
            this.leagueTablesService = leagueTablesService;
            cache = memoryCache;
        }

        public ICollection<LeagueTable> GetByCode(int code)
        {
            string key = $"league-tables_{code}";

            ICollection<LeagueTable> leagueTables = cache.GetOrCreate(key, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
    
                // ICollection<LeagueTable> lTs = leagueTablesService.GetByCode(code);

                // Add(lTs);

                return context.LeagueTables.Where(lt => lt.Code == code).ToList();
            });

            return leagueTables;
        }

        // private void Add(IEnumerable<LeagueTable> items)
        // {
        //     foreach (IGrouping<int, LeagueTable> leagueTableGrouping in items.GroupBy(lt => lt.Id))
        //     {
        //         if (!context.LeagueTables.Any(lt => lt.Id == leagueTableGrouping.Key))
        //         {
        //             context.LeagueTables.Add(leagueTableGrouping.First());
        //         }
        //     }

        //     context.SaveChanges();
        // }
    }
}