using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FS.Core.Helpers;
using FS.Core.Interfaces.Clients;
using FS.Core.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FS.Core.Clients
{
    public class TweetsClient : ITweetsClient
    {
        private readonly IConfiguration configuration;
        private readonly string token;

        public TweetsClient(IConfiguration configuration)
        {
            this.configuration = configuration;

            string consumerKey = configuration["Twitter:ConsumerKey"];
            string consumerSecret = configuration["Twitter:ConsumerSecret"];

            string tokenCredentialsEncoded = GetTokenCredentialsEncoded(consumerKey, consumerSecret);
            token = GetToken(tokenCredentialsEncoded);
        }

        public JObject GetByWord(string word)
        {
            string tweetsSearchingUrl = configuration["Twitter:TweetsSearchingUrl"];

            string query = HttpUtility.UrlEncode(word);
            string url = string.Format(tweetsSearchingUrl, query);

            HttpHelper.HttpHelperResponse response = HttpHelper.Get(
                url,
                new Dictionary<string, string>(new[]{new KeyValuePair<string, string>(
                    "Authorization", $"Bearer {token}"
                )})
            );
            
            return JObject.Parse(response.ResponseString);
        }

        private static string GetTokenCredentialsEncoded(string consumerKey, string consumerSecret)
        {
            string consumerKeyEncoded = HttpUtility.UrlEncode(consumerKey);
            string consumerSecretEncoded = HttpUtility.UrlEncode(consumerSecret);
            string tokenCredentials = $"{consumerKeyEncoded}:{consumerSecretEncoded}";
            byte[] tokenCredentialsBytes = Encoding.UTF8.GetBytes(tokenCredentials);

            return Convert.ToBase64String(tokenCredentialsBytes);
        }

        private string GetToken(string tokenCredentialsEncoded)
        {
            HttpHelper.HttpHelperResponse response = HttpHelper.Post(
                configuration["Twitter:OauthUrl"],
                "grant_type=client_credentials",
                "application/x-www-form-urlencoded",
                new Dictionary<string, string>(new[] {new KeyValuePair<string, string>(
                    "Authorization", $"Basic {tokenCredentialsEncoded}"
                )})
            );

            JObject json = JObject.Parse(response.ResponseString);

            if (!json.ContainsKey("access_token"))
            {
                return null;
            }

            return json["access_token"].ToString();
        }
    }
}
