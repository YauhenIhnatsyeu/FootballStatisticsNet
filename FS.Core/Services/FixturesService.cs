using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FS.Core.Extensions;
using FS.Core.Interfaces.Clients;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using FS.Core.Utils;
using Newtonsoft.Json.Linq;

namespace FS.Core.Services
{
    public class FixturesService : IFixturesService
    {
        private readonly IFootballClient footballClient;

        public FixturesService(IFootballClient footballClient)
        {
            this.footballClient = footballClient;
        }

        public ICollection<Fixture> GetByTeamIdAndDates(int code, DateTime fromDate, DateTime toDate)
        {
            JObject json = footballClient.GetFixturesByTeamCodeAndDates(code, fromDate, toDate);

            if (json == null)
            {
                return null;
            }

            JToken fixturesJson = ExtractFixturesJson(json);

            if (fixturesJson == null)
            {
                return null;
            }

            return ExtractFixturesFromJson(fixturesJson);
        }

        private static JToken ExtractFixturesJson(JObject json)
        {
            return json.ContainsKey("fixtures")
                ? json["fixtures"]
                : null;
        }

        private static ICollection<Fixture> ExtractFixturesFromJson(JToken fixturesJson)
        {
            var fixtures = new List<Fixture>();

            foreach (JToken fixtureJson in fixturesJson.Children().ToList())
            {
                if (fixtureJson == null) continue;

                Fixture fixture = fixtureJson.ToObject<Fixture>();

                AddCodeToFixture(fixture, fixtureJson);
                AddIsFinishedToFixture(fixture, fixtureJson);

                fixtures.Add(fixture);
            }

            return fixtures;
        }

        private static void AddCodeToFixture(Fixture fixture, JToken fixturesJson)
        {
            if (fixturesJson == null) return;
            if (!fixturesJson.ContainsKeysTree("_links", "self", "href"))
            {
                return;
            }

            string fixturesUrl = fixturesJson["_links"]["self"]["href"].ToString();
            string lastPartOfFixturesUrl = UrlUtils.GetLastPartOfUrl(fixturesUrl);

            if (int.TryParse(lastPartOfFixturesUrl, out var code))
            {
                fixture.Code = code;
            }
        }

        private static void AddIsFinishedToFixture(Fixture fixture, JToken fixturesJson)
        {
            if (fixturesJson == null) return;
            if (!fixturesJson.ContainsKey("status"))
            {
                return;
            }

            string status = fixturesJson["status"].ToString();

            fixture.IsFinished = status == Fixture.FixtureStatuses.Finished;
        }
    }
}
