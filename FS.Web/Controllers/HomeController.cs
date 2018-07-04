using Microsoft.AspNetCore.Mvc;

namespace FS.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("{*url}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}