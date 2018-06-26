using System.IO;
using CloudinaryDotNet.Actions;

namespace FS.Core.Interfaces
{
    public interface ICloudinaryService
    {
        ImageUploadResult UploadFile(string name, Stream stream);
        bool Exists(string publicId);
        bool Exists(string publicId, out GetResourceResult getResourceResult);
    }
}