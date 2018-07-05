using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

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

        public FunClub FilterUsersFunClub(Func<UserFunClub, bool> func)
        {
            FunClub funClub = this;
            funClub.UsersFunClub = funClub.UsersFunClub.Where(func).ToList();
            return funClub;
        }

        public bool IsCreatedBy(IdentityUser user)
        {
            return UsersFunClub.Any(
                ufc => ufc.UserId == user.Id && ufc.UserIsCreator == true
            );
        }
    }
}