using System.Collections.Generic;
using System.Linq;
using FS.Core.Interfaces.Repositories;
using FS.Core.Interfaces.Services;
using FS.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FS.DataAccess.Data
{
    public class UsersContext : IdentityDbContext<User>
    {
        private readonly ILeagueTeamsService leagueTeamsService;
        private readonly ILeagueTablesService leagueTablesService;

        public UsersContext(DbContextOptions options, ILeagueTeamsService leagueTeamsService, ILeagueTablesService leagueTablesService) : base(options)
        {
            this.leagueTeamsService = leagueTeamsService;
            this.leagueTablesService = leagueTablesService;
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

            builder.Entity<LeagueTable>(typeBuilder => typeBuilder
                .HasOne(leagueTable => leagueTable.Team)
                .WithMany(team => team.LeagueTable)
                .HasForeignKey(leagueTable => leagueTable.TeamId)
                .HasConstraintName("FK_LeagueTable_TeamId"));

            builder.Entity<Team>(typeBuilder =>
                typeBuilder.HasKey(team => team.Id));

            builder.Entity<FanClub>(typeBuilder =>
                typeBuilder.HasKey(fanClub => fanClub.Id));

            builder.Entity<FanClub>(typeBuilder => typeBuilder
                .HasOne(fanClub => fanClub.Team)
                .WithMany(team => team.FanClubs)
                .HasForeignKey(fanClub => fanClub.TeamId)
                .HasConstraintName("FK_FanClub_TeamId"));

            builder.Entity<FavoriteTeam>(typeBuilder =>
                typeBuilder.HasKey(teams => new {teams.UserId, teams.TeamId}));

            builder.Entity<UserFanClub>(typeBuilder =>
                typeBuilder.HasKey(userFanClub => new {userFanClub.UserId, userFanClub.FanClubId}));


            // var leagueTeamsDictionary = new Dictionary<int, ICollection<Team>>();

            // new int[] { 2000, 2001, 2002, 2003 }.ToList().ForEach(code => {
            //     leagueTeamsDictionary.Add(
            //         code,
            //         leagueTeamsService.GetByCode(code)
            //             .GroupBy(lt => lt.Id)
            //             .Select(group => group.First())
            //             .ToList());
            // });

            ICollection<Team> leagueTeams = new int[] { 2000, 2001, 2002, 2003 }.ToList().SelectMany(code =>
                leagueTeamsService.GetByCode(code))
                    .GroupBy(lt => lt.Id)
                    .Select(group => group.First())
                    .ToList();
            
            ICollection<LeagueTable> leagueTables = new int[] { 2000, 2001, 2002, 2003 }.ToList().SelectMany(code =>
                leagueTablesService.GetByCode(code)).ToList();
            
            ICollection<LeagueTable> filteredLeagueTables = new List<LeagueTable>();

            foreach (LeagueTable leagueTable in leagueTables)
            {
                Team team = leagueTeams.FirstOrDefault(t => t.Code == leagueTable.TeamCode);

                if (team != null)
                {
                    leagueTable.TeamId = team.Id;
                    leagueTable.Team = team;

                    filteredLeagueTables.Add(leagueTable);
                }
            }

            // new int[] { 2000, 2001, 2002, 2003 }.ToList().ForEach(code =>
            //     builder.Entity<Team>().HasData(leagueTeamsService.GetByCode(code).ToArray()));
                
            // new int[] { 2000, 2001, 2002, 2003 }.ToList().ForEach(code => {
                
            // }
            builder.Entity<Team>().HasData(leagueTeams.ToArray());
            builder.Entity<LeagueTable>().HasData(filteredLeagueTables.Select(flt => new {
                TeamId = flt.TeamId,
                Id = flt.Id,
                Code = flt.Code,
                Position = flt.Position,
                TeamName = flt.TeamName,
                TeamCode = flt.TeamCode,
                PlayedGames = flt.PlayedGames,
                Won = flt.Won,
                Draw = flt.Draw,
                Lost = flt.Lost,
                GoalsFor = flt.GoalsFor,
                GoalsAgainst = flt.GoalsAgainst,
                Points = flt.Points
            }).ToArray());
            // builder.Entity<LeagueTable>().HasData(new {
            //     TeamId = 2,
            //     Id = "2222",
            //     Code = 3,
            //     Position = 3,
            //     TeamName = "flt.TeamName"
            // });
            // builder.Entity<LeagueTable>().HasData(filteredLeagueTables.ToArray());
            // builder.Entity<LeagueTable>(lt =>
            // {
            //     lt.HasData(new LeagueTable { Id = "f", TeamId = 1 });
            //     lt.OwnsOne(t => t.Team).HasData(new Team { Id = 1 });
            // });
        }
    }
}