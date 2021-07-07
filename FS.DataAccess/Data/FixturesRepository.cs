using System;
using System.Collections.Generic;
using System.Text;
using FS.Core.Interfaces.Repositories;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using Microsoft.Extensions.Caching.Memory;

namespace FS.DataAccess.Data
{
    public class FixturesRepository : IFixturesRepository
    {
        private readonly IMemoryCache cache;
        private readonly IFixturesService fixturesService;

        public FixturesRepository(IMemoryCache cache, IFixturesService fixturesService)
        {
            this.cache = cache;
            this.fixturesService = fixturesService;
        }

        public ICollection<Fixture> GetByTeamIdAndDates(int code, DateTime fromDate, DateTime toDate)
        {
            string key = $"fixtures_{code}_{fromDate:yyyy-MM-dd}_{toDate:yyyy-MM-dd}";

            ICollection<Fixture> fixtures = cache.GetOrCreate(key, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                return fixturesService.GetByTeamIdAndDates(code, fromDate, toDate);
            });

            return fixtures;
        }
    }
}
