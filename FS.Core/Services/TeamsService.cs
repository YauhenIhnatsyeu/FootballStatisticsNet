using FS.Core.Interfaces.Clients;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using Newtonsoft.Json.Linq;

namespace FS.Core.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly IFootballClient footballClient;

        public TeamsService(IFootballClient footballClient)
        {
            this.footballClient = footballClient;
        }

        public Team GetByCode(int code)
        {
            JObject teamJson = footballClient.GetTeamByCode(code);

            if (teamJson == null)
            {
                return null;
            }

            Team team = teamJson.ToObject<Team>();

            team.Code = code;

            return team;
        }
    }
}