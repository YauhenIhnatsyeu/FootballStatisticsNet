using System;
using System.Collections.Generic;
using System.Text;
using FS.Core.Interfaces.Repositories;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using Microsoft.Extensions.Caching.Memory;

namespace FS.DataAccess.Data
{
    public class Head2HeadRepository : IHead2HeadRepository
    {
        private readonly IMemoryCache cache;
        private readonly IHead2HeadService head2HeadService;

        public Head2HeadRepository(IMemoryCache cache, IHead2HeadService head2HeadService)
        {
            this.cache = cache;
            this.head2HeadService = head2HeadService;
        }

        public Head2Head GetByFixtureCode(int code)
        {
            string key = $"head-2-head_{code}";

            Head2Head head2Head = cache.GetOrCreate(key, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                return head2HeadService.GetByFixtureCode(code);
            });

            return head2Head;
        }
    }
}
