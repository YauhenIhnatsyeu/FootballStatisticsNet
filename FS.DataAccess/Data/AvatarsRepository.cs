﻿using System.IO;
using System.Net;
using CloudinaryDotNet.Actions;
using FS.Core.Interfaces.Repositories;
using FS.Core.Interfaces.Services;

namespace FS.Infrastructure.Data
{
    public class AvatarsRepository : IAvatarsRepository
    {
        private readonly ICloudinaryService cloudinaryService;

        public AvatarsRepository(ICloudinaryService cloudinaryService)
        {
            this.cloudinaryService = cloudinaryService;
        }

        public string Add(string name, Stream stream)
        {
            ImageUploadResult uploadResult = cloudinaryService.UploadFile(name, stream);
            return uploadResult.StatusCode == HttpStatusCode.OK
                ? uploadResult.PublicId
                : null;
        }

        public string Get(string id)
        {
            GetResourceResult getResourceResult = cloudinaryService.GetFile(id);
            return getResourceResult.StatusCode == HttpStatusCode.OK
                ? getResourceResult.SecureUrl
                : null;
        }
    }
}