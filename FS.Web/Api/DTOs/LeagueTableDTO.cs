namespace FS.Core.Models
{
    public class LeagueTableDTO
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public string TeamName { get; set; }
        public int PlayedGames { get; set; }
        public int Won { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int Points { get; set; }
    }
}