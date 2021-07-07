using System.IO;

namespace FS.Core.Interfaces.Repositories
{
    public interface IAvatarsRepository
    {
        string Add(string name, Stream stream);
        string GetUrlById(string id);
    }
}