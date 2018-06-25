using CloudinaryDotNet;

namespace FS.Core.Helpers
{
    public static class CloudinaryHelper
    {
        public static Cloudinary GetCloudinary(string cloud, string apiKey, string apiSecret)
        {
            return new Cloudinary(new Account(cloud, apiKey, apiSecret));
        }
    }
}