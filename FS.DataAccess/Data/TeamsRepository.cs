using System.Linq;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;
using FS.Core.Helpers;
using FS.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace FS.DataAccess.Data
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly UsersContext context;
        private readonly ITeamsService teamsService;

        public TeamsRepository(UsersContext context, ITeamsService teamsService)
        {
            this.context = context;
            this.teamsService = teamsService;
        }

        public Team GetByCode(int code)
        {
            Team team = FindByCode(code);

            if (team != null)
            {
                return team;
            }

            team = teamsService.GetByCode(code);

            if (team != null)
            {
                Add(team);

                return FindByCode(code);
            }

            return null;
        }

        private void Add(Team item)
        {
            context.Teams.Add(item);
            context.SaveChanges();
        }

        private Team FindByCode(int code)
        {
            return context.Teams.FirstOrDefault(t => t.Code == code);
        }
    }
}