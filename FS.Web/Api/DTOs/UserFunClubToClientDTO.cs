﻿using FS.Core.Enums;

namespace FS.Web.Api.DTOs
{
    public class UserFunClubToClientDTO
    {
        public UserToClientDTO User { get; set; }
        public bool UserIsCreator { get; set; }
        public MemberStatus MemberStatus { get; set; }
    }
}