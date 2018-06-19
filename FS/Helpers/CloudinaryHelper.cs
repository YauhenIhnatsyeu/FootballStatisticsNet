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
    }
}