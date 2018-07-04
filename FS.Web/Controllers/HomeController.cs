using Microsoft.AspNetCore.Mvc;

namespace FS.Web.Controllers
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