using System.IO;
using System.Net;
using CloudinaryDotNet.Actions;
using FS.Core.Interfaces.Clients;
using FS.Core.Interfaces.Repositories;

namespace FS.DataAccess.Data
{
    public class AvatarsRepository : IAvatarsRepository
    {
        private readonly IAvatarClient avatarClient;

        public AvatarsRepository(IAvatarClient avatarClient)
        {
            this.avatarClient = avatarClient;
        }

        public string Add(string name, Stream stream)
        {
            ImageUploadResult uploadResult = avatarClient.Add(name, stream);
            return uploadResult.StatusCode == HttpStatusCode.OK
                ? uploadResult.PublicId
                : null;
        }

        public string GetUrlById(string id)
        {
            GetResourceResult getResourceResult = avatarClient.Get(id);
            return getResourceResult.StatusCode == HttpStatusCode.OK
                ? getResourceResult.SecureUrl
                : null;
        }
    }
}