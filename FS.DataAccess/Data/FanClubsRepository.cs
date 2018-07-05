using System;
using System.Collections.Generic;
using System.Linq;
using FS.Core.Enums;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FS.DataAccess.Data
{
    public class FanClubsRepository : IFanClubsRepository
    {
        private readonly UsersContext context;

        public FanClubsRepository(UsersContext context)
        {
            this.context = context;
        }

        public IReadOnlyList<FanClub> Get()
        {
            return context.FanClubs
                .Include(fc => fc.Team)
                .Include(fc => fc.UsersFanClub)
                    .ThenInclude(ufc => ufc.User)
                .Include(fc => fc.UsersFanClub)
                    .ThenInclude(ufc => ufc.FanClub)
                .ToList();
        }

        public void Add(FanClub item)
        {
            context.FanClubs.Add(item);
            context.SaveChanges();
        }

        public void Remove(FanClub item)
        {
            context.FanClubs.Remove(item);
            context.SaveChanges();
        }

        public FanClub FindById(int id)
        {
            return Get().FirstOrDefault(fanClub => fanClub.Id == id);
        }
    }
}