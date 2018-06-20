using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FS.Models
{
    public class User : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public string AvatarUrl { get; set; }

        public virtual ICollection<FavoriteTeam> FavoriteTeams { get; set; }
        public virtual ICollection<UserFunClub> UserFunClubs { get; set; }
    }
}