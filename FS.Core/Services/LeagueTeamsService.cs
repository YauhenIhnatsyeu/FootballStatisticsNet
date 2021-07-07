﻿using System.Collections.Generic;
using System.Linq;
using FS.Core.Extensions;
using FS.Core.Interfaces.Clients;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;
using FS.Core.Utils;
using Newtonsoft.Json.Linq;

namespace FS.Core.Services
{
    public class LeagueTeamsService : ILeagueTeamsService
    {
        private readonly IFootballClient footballClient;

        public LeagueTeamsService(IFootballClient footballClient)
        {
            this.footballClient = footballClient;
        }

        public ICollection<Team> GetByCode(int code)
        {
            JObject json = footballClient.GetLeagueTeamsByCode(code);

            if (json == null)
            {
                return null;
            }

            JToken leagueTeamsJson = ExtractLeagueTeamsJson(json);

            if (leagueTeamsJson == null)
            {
                return null;
            }

            return ExtractLeagueTeamsFromJson(leagueTeamsJson);
        }

        private static JToken ExtractLeagueTeamsJson(JObject json)
        {
            return json.ContainsKey("teams")
                ? json["teams"]
                : null;
        }

        private static ICollection<Team> ExtractLeagueTeamsFromJson(JToken leagueTeamsJson)
        {
            var leagueTeams = new List<Team>();

            foreach (JToken teamJson in leagueTeamsJson.Children().ToList())
            {
                if (teamJson == null) continue;

                Team team = teamJson.ToObject<Team>();

                AddCodeToTeam(team, teamJson);
                MakeCrestUrlHttps(team, teamJson);

                leagueTeams.Add(team);
            }

            return leagueTeams;
        }

        private static void AddCodeToTeam(Team team, JToken teamJson)
        {
            // if (teamJson == null) return;
            // if (!teamJson.ContainsKeysTree("_links", "self", "href"))
            // {
            //     return;
            // }

            // string teamUrl = teamJson["_links"]["self"]["href"].ToString();
            // string lastPartOfTeamUrl = UrlUtils.GetLastPartOfUrl(teamUrl);

            // if (int.TryParse(lastPartOfTeamUrl, out var code))
            // {
            //     team.Code = code;
            // }

            if (teamJson == null) return;
            if (!teamJson.ContainsKeysTree("team", "id"))
            {
                return;
            }

            if (int.TryParse(teamJson["team"]["id"].ToString(), out int code)) {
                team.Code = code;
            }
        }

        private static void MakeCrestUrlHttps(Team team, JToken teamJson)
        {
            if (teamJson == null) return;
            if (!((JObject) teamJson).ContainsKey("crestUrl")) return;

            string crestUrl = teamJson["crestUrl"].ToString();

            team.CrestUrl = UrlUtils.HttpToHttps(crestUrl);
        }
    }
}