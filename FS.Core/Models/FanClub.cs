using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace FS.Core.Models
{
    public class FanClub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }

        public virtual Team Team { get; set; }
        public virtual ICollection<UserFanClub> UsersFanClub { get; set; }

        public FanClub FilterUsersFanClub(Func<UserFanClub, bool> func)
        {
            FanClub fanClub = this;
            fanClub.UsersFanClub = fanClub.UsersFanClub.Where(func).ToList();
            return fanClub;
        }

        public bool IsCreatedBy(IdentityUser user)
        {
            return UsersFanClub.Any(
                ufc => ufc.UserId == user.Id && ufc.UserIsCreator == true
            );
        }
    }
}