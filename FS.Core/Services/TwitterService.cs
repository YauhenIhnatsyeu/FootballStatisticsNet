using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using FS.Core.Helpers;
using FS.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace FS.Core.Services
{
    public class TwitterService : ITwitterService
    {
        private readonly IConfiguration configuration;
        private readonly string token;

        public TwitterService(IConfiguration configuration)
        {
            this.configuration = configuration;

            string consumerKey = configuration["Twitter:ConsumerKey"];
            string consumerSecret = configuration["Twitter:ConsumerSecret"];

            string tokenCredentialsEncoded = TwitterHelper.GetTokenCredentialsEncoded(consumerKey, consumerSecret);
            token = GetTokenAsync(tokenCredentialsEncoded).Result;
        }

        public async Task<string> SendApiRequestAsync(string url)
        {
            if (url == null || token == null)
            {
                return null;
            }

            using (HttpClient httpClient = TwitterHelper.GetAuthenticationHttpClient(token))
            {
                return await httpClient.GetStringAsync(url);
            }
        }

        public async Task<string> SendSearhTweetsApiRequest(string text)
        {
            string tweetsSearchingUrlTemplate = configuration["Twitter:TweetsSearchingUrl"];

            string query = HttpUtility.UrlEncode(text);
            string url = string.Format(tweetsSearchingUrlTemplate, query);

            return await SendApiRequestAsync(url);
        }

        private async Task<string> GetTokenAsync(string tokenCredentialsEncoded)
        {
            using (HttpClient httpClient = TwitterHelper.GetAuthorizationHttpClient(tokenCredentialsEncoded))
            {
                HttpResponseMessage response = await httpClient.PostAsync(
                    configuration["Twitter:OauthUrl"],
                    TwitterHelper.GetAuthorizationHttpContent()
                );

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                string respose = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(respose);
                string tokenKey = configuration["Twitter:TokenKey"];

                if (!json.ContainsKey(tokenKey))
                {
                    return null;
                }

                return json[tokenKey].ToString();
            }
        }
    }
}