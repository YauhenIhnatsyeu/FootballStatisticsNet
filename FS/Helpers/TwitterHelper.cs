using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FS.Helpers
{
    public static class TwitterHelper
    {
        public static string GetTokenCredentialsEncoded(string consumerKey, string consumerSecret)
        {
            string consumerKeyEncoded = HttpUtility.UrlEncode(consumerKey);
            string consumerSecretEncoded = HttpUtility.UrlEncode(consumerSecret);
            string tokenCredentials = $"{consumerKeyEncoded}:{consumerSecretEncoded}";
            byte[] tokenCredentialsBytes = Encoding.UTF8.GetBytes(tokenCredentials);

            return Convert.ToBase64String(tokenCredentialsBytes);
        }

        public static HttpClient GetAuthorizationHttpClient(string tokenCredentialsEncoded)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", tokenCredentialsEncoded);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            return httpClient;
        }

        public static HttpContent GetAuthorizationHttpContent()
        {
            return new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            });
        }

        public static HttpClient GetAuthenticationHttpClient(string token)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return httpClient;
        }
    }
}
