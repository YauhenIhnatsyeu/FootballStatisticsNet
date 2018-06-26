using System;
using System.Threading.Tasks;
using System.Web;
using FS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace FS.Controllers
{
    public class TwitterController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly ITwitterService twitterService;

        public TwitterController(ITwitterService twitterService, IConfiguration configuration)
        {
            this.twitterService = twitterService;
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("/api/twitter/search")]
        public async Task<IActionResult> Search()
        {
            string queryKey = configuration["Twitter:QueryKey"];

            if (!HttpContext.Request.Query.ContainsKey(queryKey)) return BadRequest();

            string tweetsSearchingUrlTemplate = configuration["Twitter:TweetsSearchingUrl"];

            string query = HttpUtility.UrlEncode(HttpContext.Request.Query[queryKey]);
            string url = String.Format(tweetsSearchingUrlTemplate, query);

            string responseString = await twitterService.SendApiRequestAsync(url);
            var json = JObject.Parse(responseString);

            return Ok(new {SearchResult = json});
        }
    }
}