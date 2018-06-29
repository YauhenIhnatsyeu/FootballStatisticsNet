using System.Collections.Generic;

namespace FS.Api.DTOs
{
    public class FunClubToServerDTO
    {
        public string Name { get; set; }
        public int TeamId { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public IEnumerable<string> UsersIds { get; set; }
    }
}