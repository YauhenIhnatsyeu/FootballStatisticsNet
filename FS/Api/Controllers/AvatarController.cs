using System.IO;
using FS.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FS.Api.Controllers
{
    public class AvatarController : Controller
    {
        private readonly IAvatarsRepository avatarsRepository;

        public AvatarController(IAvatarsRepository avatarsRepository)
        {
            this.avatarsRepository = avatarsRepository;
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

            string avatarId = avatarsRepository.Add(
                $"avatar-{avatarHashCode}",
                avatarStream
            );

            return avatarId == null
                ? BadRequest()
                : (IActionResult) Ok(new {AvatarId = avatarId});
        }
    }
}