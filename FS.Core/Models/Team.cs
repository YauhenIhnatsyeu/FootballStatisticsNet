using System.Collections.Generic;

namespace FS.Core.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int Code { get; set; }

        public virtual ICollection<FavoriteTeam> FavoriteTeams { get; set; }
        public virtual ICollection<FanClub> FanClubs { get; set; }
    }
}