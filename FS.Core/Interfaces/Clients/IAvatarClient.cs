using System.IO;
using CloudinaryDotNet.Actions;

namespace FS.Core.Interfaces.Clients
{
    public interface IAvatarClient
    {
        ImageUploadResult Add(string name, Stream stream);
        GetResourceResult Get(string publicId);
    }
}