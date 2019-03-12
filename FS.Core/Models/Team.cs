using System.Collections.Generic;
using Newtonsoft.Json;

namespace FS.Core.Models
{
    public class Team
    {
        public int Id { get; set; }

        [JsonIgnore]
        public int Code { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string CrestUrl { get; set; }
        public string SquadMarketValue { get; set; }

        public virtual ICollection<LeagueTable> LeagueTable { get; set; }
        public virtual ICollection<FavoriteTeam> FavoriteTeams { get; set; }
        public virtual ICollection<FanClub> FanClubs { get; set; }
    }
}