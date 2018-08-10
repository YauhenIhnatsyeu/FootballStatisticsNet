using Newtonsoft.Json.Linq;

namespace FS.Core.Interfaces.Clients
{
    public interface IFootballClient
    {
        JObject GetLeagueByCode(int code);
        JObject GetTeamByCode(int code);
    }
}
