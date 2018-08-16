using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using FS.Core.Extensions;
using FS.Core.Helpers;
using FS.Core.Interfaces.Clients;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace FS.Core.Services
{
    public class TweetsService : ITweetsService
    {
        private readonly ITweetsClient tweetsClient;

        public TweetsService(ITweetsClient tweetsClient)
        {
            this.tweetsClient = tweetsClient;
        }

        public ICollection<Tweet> GetByWord(string word)
        {
            JObject json = tweetsClient.GetByWord(word);

            if (json == null)
            {
                return null;
            }

            if (!json.ContainsKey("statuses"))
            {
                return null;
            }

            var tweets = new List<Tweet>();
            JToken statusesJson = json["statuses"];

            foreach (JToken statusJson in statusesJson.Children())
            {
                bool isRetweet = statusJson.ContainsKey("retweeted_status");

                tweets.Add(new Tweet
                {
                    Name = statusJson.ContainsKey("user")
                        ? statusJson["user"]["name"].ToString()
                        : Tweet.UnknownName,
                    Date = statusJson.ContainsKey("created_at")
                        ? statusJson["created_at"].ToString()
                        : Tweet.UnknownDate,
                    IsRetweet = isRetweet,
                    RetweetName = isRetweet && statusJson.ContainsKeysTree("user", "name")
                        ? statusJson["retweeted_status"]["user"]["name"].ToString()
                        : Tweet.UnknownName,
                    RetweetDate = isRetweet && statusJson.ContainsKey("created_at")
                        ? statusJson["retweeted_status"]["created_at"].ToString()
                        : Tweet.UnknownDate,
                    Text = statusJson.ContainsKey("text")
                        ? statusJson["text"].ToString()
                        : Tweet.UnknownText
                });
            }

            return tweets;
        }
    }
}