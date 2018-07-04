using System;

namespace FS.Web.Api.DTOs
{
    public class UserToClientDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
    }
}