using System.IO;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FS.Core.Helpers;
using FS.Core.Interfaces.Clients;
using FS.Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;

namespace FS.Core.Clients
{
    public class AvatarClient : IAvatarClient
    {
        private readonly Cloudinary cloudinary;

        public AvatarClient(IConfiguration configuration)
        {
            cloudinary = CloudinaryHelper.GetCloudinary(
                configuration["Cloudinary:Cloud"],
                configuration["Cloudinary:ApiKey"],
                configuration["Cloudinary:ApiSecret"]
            );
        }

        public ImageUploadResult Add(string name, Stream stream)
        {
            return cloudinary?.Upload(new ImageUploadParams {File = new FileDescription(name, stream)});
        }

        public GetResourceResult Get(string publicId)
        {
            return cloudinary?.GetResource(publicId);
        }

        public struct AddResult
        {
            public bool Succeeded;
            public string AvatarId;
        }
    }
}