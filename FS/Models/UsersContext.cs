using System;
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

        public DbSet<TFavoriteTeams> FavoriteTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TFavoriteTeams>(typeBuilder =>
                typeBuilder.HasKey(teams => new {Id = teams.UserId, teams.TeamId}));

            builder.Entity<TFavoriteTeams>()
                .HasOne(teams => teams.User)
                .WithMany()
                .HasForeignKey(teams => teams.UserId)
                .HasConstraintName("FK_UserId");
        }
    }
}