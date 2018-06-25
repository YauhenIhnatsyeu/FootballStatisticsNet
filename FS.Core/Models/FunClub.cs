using System.Collections.Generic;

namespace FS.Core.Models
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