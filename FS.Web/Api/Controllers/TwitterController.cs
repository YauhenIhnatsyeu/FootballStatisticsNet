﻿using System.Threading.Tasks;
using FS.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace FS.Web.Api.Controllers
{
    [Route("api/twitter")]
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
        [Route("search")]
        public async Task<IActionResult> Search()
        {
            string queryKey = configuration["Twitter:QueryKey"];

            if (!HttpContext.Request.Query.ContainsKey(queryKey)) return BadRequest();

            string responseString =
                await twitterService.SendSearhTweetsApiRequest(HttpContext.Request.Query[queryKey]);
            JObject json = JObject.Parse(responseString);

            return Ok(new {SearchResult = json});
        }
    }
}