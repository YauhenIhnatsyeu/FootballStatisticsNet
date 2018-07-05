using FS.Core.Enums;

namespace FS.Web.Api.DTOs
{
    public class UserFanClubToClientDTO
    {
        public UserToClientDTO User { get; set; }
        public bool UserIsCreator { get; set; }
        public MemberStatus MemberStatus { get; set; }
    }
}