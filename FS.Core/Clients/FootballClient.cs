using System;
using System.Collections.Generic;
using FS.Core.Helpers;
using FS.Core.Interfaces.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace FS.Core.Clients
{
    public class FootballClient : IFootballClient
    {
        private readonly IConfiguration configuration;
        private readonly string apiToken;

        public FootballClient(IConfiguration configuration)
        {
            this.configuration = configuration;

            apiToken = configuration["Football:APIToken"];
        }

        public JObject GetLeagueTablesByCode(int code)
        {
            string url = string.Format(configuration["Football:LeagueTablesUrl"], code);
            return GetByUrl(url);
        }

        public JObject GetLeagueTeamsByCode(int code)
        {
            string url = string.Format(configuration["Football:LeagueTeamsUrl"], code);
            return GetByUrl(url);
        }

        public JObject GetTeamByCode(int code)
        {
            string url = string.Format(configuration["Football:TeamUrl"], code);
            return GetByUrl(url);
        }

        public JObject GetPlayersByTeamCode(int code)
        {
            string url = string.Format(configuration["Football:TeamUrl"], code);
            // string url = string.Format(configuration["Football:PlayersUrl"], code);
            return GetByUrl(url);
        }

        public JObject GetFixturesByTeamCodeAndDates(int code, DateTime fromDate, DateTime toDate)
        {
            string url = string.Format(configuration["Football:FixturesUrl"], code, fromDate, toDate);
            return GetByUrl(url);
        }

        public JObject GetHead2HeadsByFixtureCode(int code)
        {
            string url = string.Format(configuration["Football:Head2HeadsUrl"], code);
            return GetByUrl(url);
        }

        private JObject GetByUrl(string url)
        {
            HttpHelper.HttpHelperResponse response = HttpHelper.Get(
                url,
                new Dictionary<string, string>(new[]{new KeyValuePair<string, string>(
                    "X-Auth-Token", apiToken
                )})
            );

            return response.StatusCode == StatusCodes.Status200OK
                ? JObject.Parse(response.ResponseString)
                : null;
        }
    }
}