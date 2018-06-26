using System.IO;
using System.Net;
using CloudinaryDotNet.Actions;
using FS.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FS.Api.Controllers
{
    public class AvatarController : Controller
    {
        private readonly ICloudinaryService cloudinaryService;

        public AvatarController(ICloudinaryService cloudinaryService)
        {
            this.cloudinaryService = cloudinaryService;
        }

        [HttpPost]
        [Route("/api/users/avatar")]
        [Route("/api/funclubs/avatar")]
        public IActionResult Upload()
        {
            if (HttpContext.Request.Form == null)
                return BadRequest();
            if (HttpContext.Request.Form.Files == null)
                return BadRequest();
            if (HttpContext.Request.Form.Files.Count != 1)
                return BadRequest();

            IFormFile avatar = HttpContext.Request.Form.Files[0];
            int avatarHashCode = avatar.GetHashCode();
            Stream avatarStream = avatar.OpenReadStream();

            ImageUploadResult uploadResult = cloudinaryService.UploadFile(
                $"avatar-{avatarHashCode}",
                avatarStream
            );

            if (uploadResult.StatusCode != HttpStatusCode.OK)
            {
                return BadRequest();
            }

            return Ok(new {AvatarId = uploadResult.PublicId});
        }
    }
}