using System.Collections.Generic;

namespace FS.Api.DTOs
{
    public class FunClubDTO
    {
        public string Name { get; set; }
        public int TeamId { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public IReadOnlyList<string> UsersIds { get; set; }
    }
}