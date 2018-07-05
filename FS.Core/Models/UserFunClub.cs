using FS.Core.Enums;

namespace FS.Core.Models
{
    public class UserFanClub
    {
        public string UserId { get; set; }
        public int FanClubId { get; set; }
        public bool? UserIsCreator { get; set; }
        public MemberStatus? MemberStatus { get; set; }

        public virtual User User { get; set; }
        public virtual FanClub FanClub { get; set; }
    }
}