using FS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using FS.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FS.Infrastructure.Data
{
    public class FavoriteTeamsRepository : IFavoriteTeamsRepository
    {
        private readonly UsersContext context;

        public FavoriteTeamsRepository(UsersContext context)
        {
            this.context = context;
        }

        public IReadOnlyList<FavoriteTeam> Get()
        {
            return context.FavoriteTeams.Include(ft => ft.Team).ToList();
        }

        public void Add(FavoriteTeam item)
        {
            context.FavoriteTeams.Add(item);
            context.SaveChanges();
        }

        public void Remove(FavoriteTeam item)
        {
            context.FavoriteTeams.Remove(item);
            context.SaveChanges();
        }
    }
}
