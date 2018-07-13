using Microsoft.AspNetCore.Mvc;

namespace FS.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("{*url}")]
        public IActionResult Index()
        {
            string htmlFile = System.IO.File.ReadAllText("wwwroot/index.html");

            return new ContentResult
            {
                Content = htmlFile,
                ContentType = "text/html"
            };
        }
    }
}