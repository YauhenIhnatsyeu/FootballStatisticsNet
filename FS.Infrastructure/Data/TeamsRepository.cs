﻿using System.Collections.Generic;
using System.Linq;
using FS.Core.Interfaces;
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

        public void Add(Team item)
        {
            context.Teams.Add(item);
            context.SaveChanges();
        }

        public void Remove(Team item)
        {
            context.Teams.Remove(item);
            context.SaveChanges();
        }
    }
}