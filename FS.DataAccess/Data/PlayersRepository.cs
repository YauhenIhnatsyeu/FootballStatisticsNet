using System;
using System.Collections.Generic;
using System.Text;
using FS.Core.Interfaces.Repositories;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using Microsoft.Extensions.Caching.Memory;

namespace FS.DataAccess.Data
{
    public class PlayersRepository : IPlayersRepository
    {
        private readonly IMemoryCache cache;
        private readonly IPlayersService playersService;

        public PlayersRepository(IMemoryCache cache, IPlayersService playersService)
        {
            this.cache = cache;
            this.playersService = playersService;
        }

        public ICollection<Player> GetByTeamCode(int code)
        {
            string key = $"players_{code}";

            ICollection<Player> players = cache.GetOrCreate(key, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                return playersService.GetByTeamCode(code);
            });

            return players;
        }
    }
}
