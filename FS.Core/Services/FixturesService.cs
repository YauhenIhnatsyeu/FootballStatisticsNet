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

        public static void AddCodeToFixture(Fixture fixture, JToken fixturesJson)
        {
            if (fixturesJson == null) return;
            if (!fixturesJson.ContainsKeysTree("id"))
            {
                return;
            }

            string codeString = fixturesJson["id"].ToString();
            // string lastPartOfFixturesUrl = UrlUtils.GetLastPartOfUrl(fixturesUrl);

            if (int.TryParse(codeString, out var code))
            {
                fixture.Code = code;
            }
        }

        public static void AddIsFinishedToFixture(Fixture fixture, JToken fixturesJson)
        {
            if (fixturesJson == null) return;
            if (!fixturesJson.ContainsKey("status"))
            {
                return;
            }

            string status = fixturesJson["status"].ToString();

            fixture.IsFinished = status == Fixture.FixtureStatuses.Finished;
        }

        public static void AddHomeAndAwayTeamNamesToFixture(Fixture fixture, JToken fixturesJson)
        {
            if (fixturesJson == null) return;
            if (!fixturesJson.ContainsKeysTree("homeTeam", "name")
                || !fixturesJson.ContainsKeysTree("awayTeam", "name"))
            {
                return;
            }

            fixture.HomeTeamName = fixturesJson["homeTeam"]["name"].ToString();
            fixture.AwayTeamName = fixturesJson["awayTeam"]["name"].ToString();
        }

        public static void AddDateToFixture(Fixture fixture, JToken fixturesJson)
        {
            if (fixturesJson == null) return;
            if (!fixturesJson.ContainsKeysTree("utcDate"))
            {
                return;
            }

            fixture.Date = fixturesJson["utcDate"].ToString();
        }

        public static void AddResultToFixture(Fixture fixture, JToken fixturesJson)
        {
            if (fixturesJson == null) return;
            if (!fixturesJson.ContainsKeysTree("score", "fullTime", "homeTeam")
                || !fixturesJson.ContainsKeysTree("score", "fullTime", "awayTeam"))
            {
                return;
            }

            if (int.TryParse(fixturesJson["score"]["fullTime"]["homeTeam"].ToString(), out var goalsHomeTeam)
                && int.TryParse(fixturesJson["score"]["fullTime"]["awayTeam"].ToString(), out var goalsAwayTeam))
            {
                fixture.Result = new Fixture.FixtureResult { GoalsHomeTeam = goalsHomeTeam, GoalsAwayTeam = goalsAwayTeam };
            }
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
            return json.ContainsKey("matches")
                ? json["matches"]
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
                AddHomeAndAwayTeamNamesToFixture(fixture, fixtureJson);
                AddDateToFixture(fixture, fixtureJson);
                AddResultToFixture(fixture, fixtureJson);

                fixtures.Add(fixture);
            }

            return fixtures;
        }
    }
}
