using System.Collections.Generic;

namespace FS.Web.Api.DTOs
{
    public class FanClubToClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public IEnumerable<UserFanClubToClientDTO> Users { get; set; }
    }
}