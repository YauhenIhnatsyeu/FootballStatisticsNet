using Newtonsoft.Json.Linq;

namespace FS.Core.Interfaces.Clients
{
    public interface ITeamsClient
    {
        JObject GetByCode(int code);
    }
}
