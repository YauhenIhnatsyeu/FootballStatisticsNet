using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace FS.Controllers
{
    public class TwitterController : Controller
    {
        private readonly string token;

        public TwitterController(IConfiguration configuration)
        {
            string consumerKey = configuration["Twitter:ConsumerKey"];
            string consumerSecret = configuration["Twitter:ConsumerSecret"];

            string tokenCredentialsEncoded = GetTokenCredentialsEncoded(consumerKey, consumerSecret);
            token = GetTokenAsync(tokenCredentialsEncoded).Result;
        }

        [HttpGet]
        [Route("/twitter/search")]
        public async Task<IActionResult> Search()
        {
            if (!HttpContext.Request.Query.ContainsKey("q")) return BadRequest();

            string q = HttpUtility.UrlEncode(HttpContext.Request.Query["q"]);
            string url = "https://api.twitter.com/1.1/search/tweets.json" +
                      $"?q={q}&result_type=popular&count=10";

            string responseString = await SendApiRequest(url);
            var json = JObject.Parse(responseString);

            return Ok(new {SearchResult = json});
        }

        private string GetTokenCredentialsEncoded(string consumerKey, string consumerSecret)
        {
            string consumerKeyEncoded = HttpUtility.UrlEncode(consumerKey);
            string consumerSecretEncoded = HttpUtility.UrlEncode(consumerSecret);
            string tokenCredentials = $"{consumerKeyEncoded}:{consumerSecretEncoded}";
            byte[] tokenCredentialsBytes = Encoding.UTF8.GetBytes(tokenCredentials);

            return Convert.ToBase64String(tokenCredentialsBytes);
        }

        private async Task<string> GetTokenAsync(string tokenCredentialsEncoded)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", tokenCredentialsEncoded);
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                HttpContent httpContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials")
                });

                var response = await httpClient.PostAsync("https://api.twitter.com/oauth2/token", httpContent);

                if (!response.IsSuccessStatusCode) return null;

                var resposeString = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(resposeString);

                if (!json.ContainsKey("access_token")) return null;

                return json["access_token"].ToString();
            }
        }

        private async Task<string> SendApiRequest(string url)
        {
            if (url == null) return null;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                return await httpClient.GetStringAsync(url);
            }
        }
    }
}