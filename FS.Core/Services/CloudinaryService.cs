using System.IO;
using System.Net;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FS.Core.Helpers;
using FS.Core.Interfaces;
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
            return cloudinary.Upload(new ImageUploadParams {File = new FileDescription(name, stream)});
        }

        public bool Exists(string publicId)
        {
            return cloudinary.GetResource(publicId).StatusCode == HttpStatusCode.OK;
        }

        public bool Exists(string publicId, out GetResourceResult getResourceResult)
        {
            getResourceResult = cloudinary.GetResource(publicId);
            return getResourceResult.StatusCode == HttpStatusCode.OK;
        }
    }
}