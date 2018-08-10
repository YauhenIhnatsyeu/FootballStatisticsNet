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
    public class LeagueTablesService : ILeagueTablesService
    {
        private readonly IFootballClient footballClient;

        public LeagueTablesService(IFootballClient footballClient)
        {
            this.footballClient = footballClient;
        }

        public ICollection<LeagueTable> GetByCode(int code)
        {
            JObject json = footballClient.GetLeagueTableByCode(code);

            if (json == null)
            {
                return null;
            }

            JToken leagueTablesJson = ExtractLeagueTablesJson(json);

            if (leagueTablesJson == null)
            {
                return null;
            }

            return ExtractLeagueTablesFromJson(leagueTablesJson);
        }

        private static JToken ExtractLeagueTablesJson(JObject json)
        {
            return json.ContainsKey("standing")
                ? json["standing"]
                : null;
        }

        private static ICollection<LeagueTable> ExtractLeagueTablesFromJson(JToken leagueTablesJson)
        {
            var leagueTables = new List<LeagueTable>();

            foreach (JToken tableJson in leagueTablesJson.Children().ToList())
            {
                if (tableJson == null) continue;

                LeagueTable table = tableJson.ToObject<LeagueTable>();
                AddCodeToTable(table, tableJson);

                leagueTables.Add(table);
            }

            return leagueTables;
        }

        private static void AddCodeToTable(LeagueTable table, JToken tableJson)
        {
            if (tableJson == null) return;
            if (!((JObject)tableJson).ContainsKey("_links")) return;
            if (!((JObject)tableJson["_links"]).ContainsKey("team")) return;
            if (!((JObject)tableJson["_links"]["team"]).ContainsKey("href")) return;

            string teamUrl = tableJson["_links"]["team"]["href"].ToString();
            string lastPartOfTeamUrl = UrlUtils.GetLastPartOfUrl(teamUrl);

            if (Int32.TryParse(lastPartOfTeamUrl, out var code))
            {
                table.Code = code;
            }
        }
    }
}
