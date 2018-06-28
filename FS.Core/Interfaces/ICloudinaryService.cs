using System.IO;
using CloudinaryDotNet.Actions;

namespace FS.Core.Interfaces
{
    public interface ICloudinaryService
    {
        ImageUploadResult UploadFile(string name, Stream stream);
        GetResourceResult GetFile(string publicId);
    }
}