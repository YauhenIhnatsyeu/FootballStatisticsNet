using System.Collections.Generic;
using System.Linq;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FS.DataAccess.Data
{
    public class UsersFunClubsRepository : IUsersFunClubsRepository
    {
        private readonly UsersContext context;

        public UsersFunClubsRepository(UsersContext context)
        {
            this.context = context;
        }

        public IReadOnlyList<UserFunClub> Get()
        {
            return context.UsersFunClubs
                .Include(ufc => ufc.User)
                .Include(ufc => ufc.FunClub)
                .ToList();
        }

        public UserFunClub GetByUserFunClub(UserFunClub userFunClub)
        {
            return Get().FirstOrDefault(
                ufc => ufc.UserId == userFunClub.UserId && ufc.FunClubId == userFunClub.FunClubId);
        }

        public void Add(UserFunClub item)
        {
            context.UsersFunClubs.Add(item);
            context.SaveChanges();
        }

        public void Remove(UserFunClub item)
        {
            context.UsersFunClubs.Remove(item);
            context.SaveChanges();
        }

        public void Update(UserFunClub userFunClub)
        {
            context.UsersFunClubs.Attach(userFunClub);
            context.Entry(userFunClub).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}