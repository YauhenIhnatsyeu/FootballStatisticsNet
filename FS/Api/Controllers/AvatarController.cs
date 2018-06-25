using System.Net;
using FS.Core.Interfaces;
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
        [Route("/users/avatar")]
        [Route("/funclubs/avatar")]
        public IActionResult Upload()
        {
            if (HttpContext.Request.Form == null)
                return BadRequest();
            if (HttpContext.Request.Form.Files == null)
                return BadRequest();
            if (HttpContext.Request.Form.Files.Count != 1)
                return BadRequest();

            var avatar = HttpContext.Request.Form.Files[0];
            var avatarHashCode = avatar.GetHashCode();
            var avatarStream = avatar.OpenReadStream();

            var uploadResult = cloudinaryService.UploadFile($"avatar-{avatarHashCode}", avatarStream);

            if (uploadResult.StatusCode != HttpStatusCode.OK)
            {
                return BadRequest();
            }

            return Ok(new {AvatarId = uploadResult.PublicId});
        }
    }
}