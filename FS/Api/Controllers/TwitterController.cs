using System.Threading.Tasks;
using System.Web;
using FS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FS.Controllers
{
    public class TwitterController : Controller
    {
        private readonly ITwitterService twitterService;

        public TwitterController(ITwitterService twitterService)
        {
            this.twitterService = twitterService;
        }

        [HttpGet]
        [Route("/twitter/search")]
        public async Task<IActionResult> Search()
        {
            if (!HttpContext.Request.Query.ContainsKey("q")) return BadRequest();

            string query = HttpUtility.UrlEncode(HttpContext.Request.Query["q"]);
            string url = "https://api.twitter.com/1.1/search/tweets.json" +
                         $"?q={query}&result_type=popular&count=10";

            string responseString = await twitterService.SendApiRequestAsync(url);
            var json = JObject.Parse(responseString);

            return Ok(new {SearchResult = json});
        }
    }
}