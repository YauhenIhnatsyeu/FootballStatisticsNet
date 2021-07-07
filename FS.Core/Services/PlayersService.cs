using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FS.Core.Extensions;
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

        public static void AddJerseyNumberToFixture(Player player, JToken playersJson)
        {
            if (playersJson == null) return;
            if (!playersJson.ContainsKeysTree("shirtNumber"))
            {
                return;
            }

            if (int.TryParse(playersJson["shirtNumber"].ToString(), out var shirtNumber)) {
                player.JerseyNumber = shirtNumber;
            }
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

            ICollection<Player> players = new List<Player>();

            try
            {
                foreach (JToken playerJson in playersJson.Children().ToList())
                {
                    if (playerJson == null) continue;

                    Player player = playerJson.ToObject<Player>();
                    AddJerseyNumberToFixture(player, playerJson);

                    players.Add(player);
                }

                return players.OrderBy(p => p.JerseyNumber).ToList();
            }
            catch
            {
                return null;
            }
        }

        private static JToken ExtractPlayersJson(JObject json)
        {
            return json.ContainsKey("squad")
                ? json["squad"]
                : null;
        }
    }
}
