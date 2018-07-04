using System.Collections.Generic;
using System.Linq;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;

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
            return context.UsersFunClubs.ToList();
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
    }
}