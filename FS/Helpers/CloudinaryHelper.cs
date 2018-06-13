using System.IO;
using System.Net;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace FS.Helpers
{
    public static class CloudinaryHelper
    {
        public static Cloudinary GetCloudinary(string cloud, string apiKey, string apiSecret)
        {
            return new Cloudinary(new Account(cloud, apiKey, apiSecret));
        }

        public static ImageUploadResult UploadFile(Cloudinary cloudinary, string name, Stream stream)
        {
            return cloudinary.Upload(new ImageUploadParams {File = new FileDescription(name, stream)});
        }

        public static bool Exists(Cloudinary cloudinary, string publicId)
        {
            return cloudinary.GetResource(publicId).StatusCode == HttpStatusCode.OK;
        }

        public static bool Exists(Cloudinary cloudinary, string publicId, out GetResourceResult getResourceResult)
        {
            getResourceResult = cloudinary.GetResource(publicId);
            return getResourceResult.StatusCode == HttpStatusCode.OK;
        }
    }
}