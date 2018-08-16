using System.Collections.Generic;
using System.Threading.Tasks;
using FS.Core.Interfaces.Repositories;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace FS.Web.Api.Controllers
{
    [Route("api/tweets")]
    public class TweetsController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly ITweetsRepository tweetsRepository;

        public TweetsController(IConfiguration configuration, ITweetsRepository tweetsRepository)
        {
            this.configuration = configuration;
            this.tweetsRepository = tweetsRepository;
        }

        [Route("{word}")]
        public IActionResult Search(string word)
        {
            ICollection<Tweet> tweets = tweetsRepository.GetByWord(word);

            return tweets != null
                ? (IActionResult)Json(tweets)
                : BadRequest();
        }
    }
}