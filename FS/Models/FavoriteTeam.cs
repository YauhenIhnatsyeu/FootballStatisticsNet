using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FS.Models
{
    public class FavoriteTeam
    {
        public string UserId { get; set; }
        public int TeamId { get; set; }

        public virtual User User { get; set; }
        public virtual Team Team { get; set; }
    }
}
