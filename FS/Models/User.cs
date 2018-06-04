using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FS.Models
{
    public class User : IdentityUser
    {
        private const string BIRTH_DATE = "BirthDate";
        private const string AVATAR_URL = "AvatarUrl";

        [Column(BIRTH_DATE)]
        public DateTime BirthDate { get; set; }

        [Column(AVATAR_URL)]
        public string AvatarUrl { get; set; }
    }
}