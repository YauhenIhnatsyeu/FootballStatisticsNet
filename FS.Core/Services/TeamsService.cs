using System;
using System.Collections.Generic;
using System.Text;
using FS.Core.Helpers;
using FS.Core.Interfaces.Clients;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using Newtonsoft.Json.Linq;

namespace FS.Core.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly ITeamsClient teamsClient;

        public TeamsService(ITeamsClient teamsClient)
        {
            this.teamsClient = teamsClient;
        }

        public Team GetByCode(int code)
        {
            JObject teamJson = teamsClient.GetByCode(code);

            if (teamJson == null)
            {
                return null;
            }

            var team = teamJson.ToObject<Team>();

            team.Code = code;

            return team;
        }
    }
}
