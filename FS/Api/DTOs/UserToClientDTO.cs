using System;

namespace FS.Dtos
{
    public class UserToClientDTO
    {
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
    }
}