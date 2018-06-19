using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace FS.Services
{
    public interface ICloudinaryService
    {
        ImageUploadResult UploadFile(string name, Stream stream);
        bool Exists(string publicId);
        bool Exists(string publicId, out GetResourceResult getResourceResult);
    }
}
