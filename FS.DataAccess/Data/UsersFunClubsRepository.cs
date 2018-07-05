using System.Collections.Generic;
using System.Linq;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FS.DataAccess.Data
{
    public class UsersFanClubsRepository : IUsersFanClubsRepository
    {
        private readonly UsersContext context;

        public UsersFanClubsRepository(UsersContext context)
        {
            this.context = context;
        }

        public IReadOnlyList<UserFanClub> Get()
        {
            return context.UsersFanClubs
                .Include(ufc => ufc.User)
                .Include(ufc => ufc.FanClub)
                .ToList();
        }

        public UserFanClub GetByUserFanClub(UserFanClub userFanClub)
        {
            return Get().FirstOrDefault(
                ufc => ufc.UserId == userFanClub.UserId && ufc.FanClubId == userFanClub.FanClubId);
        }

        public void Add(UserFanClub item)
        {
            context.UsersFanClubs.Add(item);
            context.SaveChanges();
        }

        public void Remove(UserFanClub item)
        {
            context.UsersFanClubs.Remove(item);
            context.SaveChanges();
        }

        public void Update(UserFanClub userFanClub)
        {
            context.UsersFanClubs.Attach(userFanClub);
            context.Entry(userFanClub).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}