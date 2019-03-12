using System;
using System.Collections.Generic;
using System.Linq;
using FS.Core.Extensions;
using FS.Core.Interfaces.Clients;
using FS.Core.Interfaces.Repositories;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using FS.Core.Utils;
using Newtonsoft.Json.Linq;

namespace FS.Core.Services
{
    public class LeagueTablesService : ILeagueTablesService
    {
        // private readonly ITeamsRepository teamsRepository;
        private readonly IFootballClient footballClient;

        public LeagueTablesService(/*ITeamsRepository teamsRepository, */IFootballClient footballClient)
        {
            // this.teamsRepository = teamsRepository;
            this.footballClient = footballClient;
        }

        public ICollection<LeagueTable> GetByCode(int code)
        {
            JObject json = footballClient.GetLeagueTablesByCode(code);

            if (json == null)
            {
                return null;
            }

            JToken leagueTablesJson = ExtractLeagueTablesJson(json);

            if (leagueTablesJson == null)
            {
                return null;
            }

            return ExtractLeagueTablesFromJson(leagueTablesJson, code);
        }

        private static JToken ExtractLeagueTablesJson(JObject json)
        {
            var a = JToken.FromObject(json["standings"].Children().SelectMany(s => s["table"]));
            return a;
        }

        private ICollection<LeagueTable> ExtractLeagueTablesFromJson(JToken leagueTablesJson, int code)
        {
            var leagueTables = new List<LeagueTable>();

            foreach (JToken tableJson in leagueTablesJson.Children().ToList())
            {
                if (tableJson == null) continue;

                LeagueTable table = tableJson.ToObject<LeagueTable>();
                AddCodeToTable(table, tableJson);
                table.Id = Guid.NewGuid().ToString();
                table.Code = code;
                AddTeamNameToTable(table, tableJson);

                leagueTables.Add(table);
            }

            return leagueTables;
        }

        private void AddCodeToTable(LeagueTable table, JToken tableJson)
        {
            if (tableJson == null) return;
            if (!tableJson.ContainsKeysTree("team", "id"))
            {
                return;
            }

            if (int.TryParse(tableJson["team"]["id"].ToString(), out int code)) {
                table.TeamCode = code;
            }
        }

        private static void AddTeamNameToTable(LeagueTable table, JToken tableJson)
        {
            if (tableJson == null) return;
            if (!tableJson.ContainsKeysTree("team", "name"))
            {
                return;
            }

            string teamName = tableJson["team"]["name"].ToString();

            table.TeamName = teamName;
        }
    }
}