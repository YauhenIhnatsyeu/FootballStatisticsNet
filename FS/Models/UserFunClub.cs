using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FS.Models
{
    public class UserFunClub
    {
        public string UserId { get; set; }
        public int FunClubId { get; set; }
        public bool? UserIsCreator { get; set; }

        public virtual User User { get; set; }
        public virtual FunClub FunClub { get; set; }
    }
}
