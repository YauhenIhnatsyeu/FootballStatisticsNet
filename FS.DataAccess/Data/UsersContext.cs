using FS.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FS.DataAccess.Data
{
    public class UsersContext : IdentityDbContext<User>
    {
        public UsersContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LeagueTable> LeagueTables { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<FanClub> FanClubs { get; set; }
        public DbSet<FavoriteTeam> FavoriteTeams { get; set; }
        public DbSet<UserFanClub> UsersFanClubs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<LeagueTable>(typeBuilder =>
                typeBuilder.HasKey(leagueTable => leagueTable.Id));

            builder.Entity<LeagueTable>(typeBuilder =>
                typeBuilder
                    .HasOne(leagueTable => leagueTable.Team)
                    .WithOne(team => team.LeagueTable)
                    .HasForeignKey<LeagueTable>(leagueTable => leagueTable.TeamId)
                    .HasConstraintName("FK_LeagueTable_TeamId"));

            builder.Entity<Team>(typeBuilder =>
                typeBuilder.HasKey(team => team.Id));

            builder.Entity<FanClub>(typeBuilder =>
                typeBuilder.HasKey(fanClub => fanClub.Id));

            builder.Entity<FavoriteTeam>(typeBuilder =>
                typeBuilder.HasKey(teams => new {teams.UserId, teams.TeamId}));

            builder.Entity<UserFanClub>(typeBuilder =>
                typeBuilder.HasKey(userFanClub => new {userFanClub.UserId, userFanClub.FanClubId}));
        }
    }
}