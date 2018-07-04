﻿using FS.Core.Enums;

namespace FS.Core.Models
{
    public class UserFunClub
    {
        public string UserId { get; set; }
        public int FunClubId { get; set; }
        public bool? UserIsCreator { get; set; }
        public MemberStatus? MemberStatus { get; set; }

        public virtual User User { get; set; }
        public virtual FunClub FunClub { get; set; }
    }
}