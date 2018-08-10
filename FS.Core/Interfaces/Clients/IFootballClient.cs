using Newtonsoft.Json.Linq;

namespace FS.Core.Interfaces.Clients
{
    public interface IFootballClient
    {
        JObject GetLeagueTableByCode(int code);
        JObject GetTeamByCode(int code);
    }
}
