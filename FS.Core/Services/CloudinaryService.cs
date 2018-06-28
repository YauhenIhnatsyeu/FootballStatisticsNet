using System.IO;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FS.Core.Helpers;
using FS.Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;

namespace FS.Core.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryService(IConfiguration configuration)
        {
            cloudinary = CloudinaryHelper.GetCloudinary(
                configuration["Cloudinary:Cloud"],
                configuration["Cloudinary:ApiKey"],
                configuration["Cloudinary:ApiSecret"]
            );
        }

        public ImageUploadResult UploadFile(string name, Stream stream)
        {
            return cloudinary?.Upload(new ImageUploadParams {File = new FileDescription(name, stream)});
        }

        public GetResourceResult GetFile(string publicId)
        {
            return cloudinary?.GetResource(publicId);
        }
    }
}