using System;

namespace FS.Dtos
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarId { get; set; }
        public string AvatarUrl { get; set; }
    }
}