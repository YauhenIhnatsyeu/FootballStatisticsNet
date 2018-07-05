using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace FS.Core.Models
{
    public class User : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public string AvatarUrl { get; set; }

        public virtual ICollection<FavoriteTeam> FavoriteTeams { get; set; }
        public virtual ICollection<UserFanClub> UserFanClubs { get; set; }
    }
}