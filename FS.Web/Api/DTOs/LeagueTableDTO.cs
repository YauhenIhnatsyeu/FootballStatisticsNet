using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Core.Models
{
    public class LeagueTableDTO
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public string TeamName { get; set; }
        public int PlayedGames { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int Goals { get; set; }
        public int GoalsAgainst { get; set; }
        public int Points { get; set; }
    }
}
