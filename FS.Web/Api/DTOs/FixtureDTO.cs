using FS.Core.Models;

namespace FS.Web.Api.DTOs
{
    public class FixtureDTO
    {
        public int Id { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public Fixture.FixtureResult Result { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public bool IsFinished { get; set; }
    }
}
