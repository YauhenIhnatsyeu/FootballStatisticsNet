using System.Collections.Generic;
using System.Linq;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;

namespace FS.Infrastructure.Data
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly UsersContext context;

        public TeamsRepository(UsersContext context)
        {
            this.context = context;
        }

        public IReadOnlyList<Team> Get()
        {
            return context.Teams.ToList();
        }

        public Team GetByTeam(Team item)
        {
            return Get().FirstOrDefault(team => team.Code == item.Code);
        }

        public void Add(Team item)
        {
            if (Contains(item))
            {
                return;
            }

            context.Teams.Add(item);
            context.SaveChanges();
        }

        public void Remove(Team item)
        {
            context.Teams.Remove(item);
            context.SaveChanges();
        }

        public bool Contains(Team item)
        {
            return GetByTeam(item) != null;
        }
    }
}