using System.Threading.Tasks;

namespace FS.Core.Interfaces.Services
{
    public interface ITwitterService
    {
        Task<string> SendApiRequestAsync(string url);
        Task<string> SendSearhTweetsApiRequest(string text);
    }
}