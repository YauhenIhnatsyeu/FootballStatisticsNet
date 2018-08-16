using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FS.Core.Interfaces.Clients;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using FS.Core.Utils;
using Newtonsoft.Json.Linq;

namespace FS.Core.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly IFootballClient footballClient;

        public PlayersService(IFootballClient footballClient)
        {
            this.footballClient = footballClient;
        }

        public ICollection<Player> GetByTeamCode(int code)
        {
            JObject json = footballClient.GetPlayersByTeamCode(code);

            if (json == null)
            {
                return null;
            }

            JToken playersJson = ExtractPlayersJson(json);

            if (playersJson == null)
            {
                return null;
            }

            ICollection<Player> players;

            try
            {
                players = playersJson.ToObject<ICollection<Player>>();
                players = players.OrderBy(p => p.JerseyNumber).ToList();
            }
            catch
            {
                return null;
            }

            return players;
        }

        private static JToken ExtractPlayersJson(JObject json)
        {
            return json.ContainsKey("players")
                ? json["players"]
                : null;
        }
    }
}
