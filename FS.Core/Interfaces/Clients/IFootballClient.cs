using System;
using Newtonsoft.Json.Linq;

namespace FS.Core.Interfaces.Clients
{
    public interface IFootballClient
    {
        JObject GetLeagueTablesByCode(int code);
        JObject GetLeagueTeamsByCode(int code);
        JObject GetTeamByCode(int code);
        JObject GetPlayersByTeamCode(int code);
        JObject GetFixturesByTeamCodeAndDates(int code, DateTime fromDate, DateTime toDate);
        JObject GetHead2HeadsByFixtureCode(int code);
    }
}