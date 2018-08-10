using System;
using System.Collections.Generic;
using System.Text;
using FS.Core.Helpers;
using FS.Core.Interfaces.Clients;
using FS.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace FS.Core.Clients
{
    public class FootballClient : IFootballClient
    {
        private readonly IConfiguration configuration;

        public FootballClient(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public JObject GetLeagueTableByCode(int code)
        {
            string url = String.Format(configuration["Football:LeagueUrl"], code);
            return GetByUrl(url);
        }

        public JObject GetTeamByCode(int code)
        {
            string url = String.Format(configuration["Football:TeamUrl"], code);
            return GetByUrl(url);
        }

        private JObject GetByUrl(string url)
        {
            HttpHelper.HttpHelperResponse response = HttpHelper.Get(url);

            return response.StatusCode == StatusCodes.Status200OK
                ? JObject.Parse(response.ResponseString)
                : null;
        }
    }
}
