using System;
using System.Collections.Generic;
using System.Text;
using FS.Core.Extensions;
using FS.Core.Interfaces.Clients;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using Newtonsoft.Json.Linq;

namespace FS.Core.Services
{
    public class Head2HeadService : IHead2HeadService
    {
        private readonly IFootballClient footballClient;

        public Head2HeadService(IFootballClient footballClient)
        {
            this.footballClient = footballClient;
        }

        public Head2Head GetByFixtureCode(int code)
        {
            JObject json = footballClient.GetHead2HeadsByFixtureCode(code);

            if (json == null)
            {
                return null;
            }

            if (!json.ContainsKey("head2head"))
            {
                return null;
            }

            if (!json.ContainsKey("fixture"))
            {
                return null;
            }

            JToken head2HeadJson = json["head2head"];

            if (!head2HeadJson.ContainsKey("fixtures"))
            {
                return null;
            }

            return new Head2Head
            {
                Fixture = json["fixture"].ToObject<Fixture>(),
                Fixtures = head2HeadJson["fixtures"].ToObject<ICollection<Fixture>>(),
                Info = head2HeadJson.ToObject<Head2Head.Head2HeadInfo>()
            };
        }
    }
}
