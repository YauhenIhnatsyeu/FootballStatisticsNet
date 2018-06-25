using System.Threading.Tasks;

namespace FS.Core.Interfaces
{
    public interface ITwitterService
    {
        Task<string> SendApiRequestAsync(string url);
    }
}