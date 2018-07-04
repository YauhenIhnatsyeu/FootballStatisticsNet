using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Web.Api.DTOs
{
    public class FunClubToClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
        public IEnumerable<UserFunClubToClientDTO> Users { get; set; }
    }
}