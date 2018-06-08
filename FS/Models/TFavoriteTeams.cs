using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FS.Models
{
    public class TFavoriteTeams
    {
        public string UserId { get; set; }
        public int TeamId { get; set; }

        public User User { get; set; }
    }
}
