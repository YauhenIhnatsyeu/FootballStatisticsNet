namespace FS.Core.Models
{
    public class Fixture
    {
        public int Code { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public FixtureResult Result { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public bool IsFinished { get; set; }

        public static class FixtureStatuses
        {
            public const string Finished = "FINISHED";
        }

        public class FixtureResult
        {
            public int GoalsHomeTeam { get; set; }
            public int GoalsAwayTeam { get; set; }
        }
    }
}
