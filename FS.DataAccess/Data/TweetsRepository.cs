using System;
using System.Collections.Generic;
using System.Text;
using FS.Core.Interfaces.Repositories;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using Microsoft.Extensions.Caching.Memory;

namespace FS.DataAccess.Data
{
    public class TweetsRepository : ITweetsRepository
    {
        private readonly IMemoryCache cache;
        private readonly ITweetsService tweetsService;

        public TweetsRepository(IMemoryCache cache, ITweetsService tweetsService)
        {
            this.cache = cache;
            this.tweetsService = tweetsService;
        }

        public ICollection<Tweet> GetByWord(string word)
        {
            string key = $"tweets_{word}";

            ICollection<Tweet> tweets = cache.GetOrCreate(key, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                return tweetsService.GetByWord(word);
            });

            return tweets;
        }
    }
}
