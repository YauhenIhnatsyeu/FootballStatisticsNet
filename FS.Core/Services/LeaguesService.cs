using System;
using FS.Core.Interfaces.Clients;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using FS.Core.Utils;

namespace FS.Core.Services
{
    public class LeaguesService : ILeaguesService
    {
        private readonly IFootballClient footballClient;

        public LeaguesService(IFootballClient footballClient)
        {
            this.footballClient = footballClient;
        }

        public ICollection<LeagueTeam> GetByCode(int code)
        {
            JObject json = footballClient.GetLeagueByCode(code);

            if (json == null)
            {
                return null;
            }

            JToken leagueJson = ExtractLeagueJson(json);

            if (leagueJson == null)
            {
                return null;
            }

            return ExtractLeagueFromJson(leagueJson);
        }

        private static JToken ExtractLeagueJson(JObject json)
        {
            return json.ContainsKey("standing")
                ? json["standing"]
                : null;
        }

        private static ICollection<LeagueTeam> ExtractLeagueFromJson(JToken leagueJson)
        {
            var league = new List<LeagueTeam>();
            ICollection<JToken> teamsJson = leagueJson.Children().ToList();

            foreach (JToken teamJson in teamsJson)
            {
                if (teamJson == null) continue;

                LeagueTeam team = teamJson.ToObject<LeagueTeam>();
                AddCodeToTeam(team, teamJson);

                league.Add(team);
            }

            return league;
        }

        private static void AddCodeToTeam(LeagueTeam team, JToken teamJson)
        {
            if (teamJson == null) return;
            if (!((JObject)teamJson).ContainsKey("_links")) return;
            if (!((JObject)teamJson["_links"]).ContainsKey("team")) return;
            if (!((JObject)teamJson["_links"]["team"]).ContainsKey("href")) return;

            string teamUrl = teamJson["_links"]["team"]["href"].ToString();
            string lastPartOfTeamUrl = UrlUtils.GetLastPartOfUrl(teamUrl);

            if (Int32.TryParse(lastPartOfTeamUrl, out var code))
            {
                team.Code = code;
            }
        }
    }
}
