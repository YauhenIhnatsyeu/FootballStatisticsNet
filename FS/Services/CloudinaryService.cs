using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FS.Helpers;
using Microsoft.Extensions.Configuration;

namespace FS.Services
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
            return cloudinary.Upload(new ImageUploadParams { File = new FileDescription(name, stream) });
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
