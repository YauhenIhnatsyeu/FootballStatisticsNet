using System.Collections.Generic;
using System.Linq;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;

namespace FS.Infrastructure.Data
{
    public class FunClubsRepository : IFunClubsRepository
    {
        private readonly UsersContext context;

        public FunClubsRepository(UsersContext context)
        {
            this.context = context;
        }

        public IReadOnlyList<FunClub> Get()
        {
            return context.FunClubs.ToList();
        }

        public void Add(FunClub item)
        {
            context.FunClubs.Add(item);
            context.SaveChanges();
        }

        public void Remove(FunClub item)
        {
            context.FunClubs.Remove(item);
            context.SaveChanges();
        }
    }
}