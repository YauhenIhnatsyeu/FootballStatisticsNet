﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FS.Models
{
    public class UsersContext : IdentityDbContext<User>
    {
        public UsersContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TFavoriteTeamsList> FavoriteTeamsLists { get; set; }
    }
}