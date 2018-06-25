using FS.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FS.Infrastructure.Data
{
    public class UsersContext : IdentityDbContext<User>
    {
        public UsersContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<FunClub> FunClubs { get; set; }
        public DbSet<FavoriteTeam> FavoriteTeams { get; set; }
        public DbSet<UserFunClub> UsersFunClubs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Team>(typeBuilder =>
                typeBuilder.HasKey(team => team.Id));

            builder.Entity<FunClub>(typeBuilder =>
                typeBuilder.HasKey(funClub => funClub.Id));

            builder.Entity<FavoriteTeam>(typeBuilder =>
                typeBuilder.HasKey(teams => new {teams.UserId, teams.TeamId}));

            builder.Entity<UserFunClub>(typeBuilder =>
                typeBuilder.HasKey(userFunClub => new {userFunClub.UserId, userFunClub.FunClubId}));
        }
    }
}