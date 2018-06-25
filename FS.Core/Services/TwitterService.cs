using System.Net.Http;
using System.Threading.Tasks;
using FS.Core.Helpers;
using FS.Core.Interfaces;
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

            using (var httpClient = TwitterHelper.GetAuthenticationHttpClient(token))
            {
                return await httpClient.GetStringAsync(url);
            }
        }

        private async Task<string> GetTokenAsync(string tokenCredentialsEncoded)
        {
            using (var httpClient = TwitterHelper.GetAuthorizationHttpClient(tokenCredentialsEncoded))
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
                var json = JObject.Parse(respose);
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