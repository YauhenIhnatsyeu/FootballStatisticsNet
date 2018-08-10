using Newtonsoft.Json.Linq;

namespace FS.Core.Interfaces.Clients
{
    public interface IFootballClient
    {
        JObject GetLeagueTablesByCode(int code);
        JObject GetLeagueTeamsByCode(int code);
        JObject GetTeamByCode(int code);
    }
}
