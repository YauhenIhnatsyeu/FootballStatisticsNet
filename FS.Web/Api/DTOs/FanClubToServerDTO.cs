using System.Collections.Generic;

namespace FS.Web.Api.DTOs
{
    public class FanClubToServerDTO
    {
        public string Name { get; set; }
        public int TeamId { get; set; }
        public string Description { get; set; }
        public string AvatarId { get; set; }
    }
}