using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FS.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int Code { get; set; }

        public virtual ICollection<FavoriteTeam> FavoriteTeams { get; set; }
        public virtual ICollection<FunClub> FunClubs { get; set; }
    }
}
