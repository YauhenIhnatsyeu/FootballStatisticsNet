using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FS.Models
{
    public class User : IdentityUser {
        private const string BIRTH_DATE = "birth_date";
        private const string PROFILE_PICTURE = "profile_picture";

        [Column(BIRTH_DATE)]
        public DateTime BirthDate { get; set; }
        [Column(PROFILE_PICTURE)]
        public string ProfilePicture { get; set; }
    }
}
