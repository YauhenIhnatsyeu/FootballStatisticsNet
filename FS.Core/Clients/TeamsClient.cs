using System;
using System.Collections.Generic;
using System.Text;
using FS.Core.Helpers;
using FS.Core.Interfaces.Clients;
using FS.Core.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace FS.Core.Clients
{
    public class TeamsClient : ITeamsClient
    {
        public JObject GetByCode(int code)
        {
            string url = $"http://api.football-data.org/v1/teams/{code}";
            HttpHelper.HttpHelperResponse response = HttpHelper.Get(url);

            return response.StatusCode == StatusCodes.Status200OK
                ? JObject.Parse(response.ResponseString)
                : null;
        }
    }
}
