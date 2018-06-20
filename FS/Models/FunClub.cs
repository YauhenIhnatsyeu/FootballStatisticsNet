using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FS.Models
{
    public class FunClub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }

        public virtual Team Team { get; set; }
        public virtual ICollection<UserFunClub> UsersFunClub { get; set; }
    }
}
