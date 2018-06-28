using System.IO;
using CloudinaryDotNet.Actions;

namespace FS.Core.Interfaces.Services
{
    public interface ICloudinaryService
    {
        ImageUploadResult UploadFile(string name, Stream stream);
        GetResourceResult GetFile(string publicId);
    }
}