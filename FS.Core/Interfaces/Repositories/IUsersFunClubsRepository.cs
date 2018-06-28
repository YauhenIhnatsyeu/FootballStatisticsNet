using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Core.Interfaces.Repositories
{
    public interface IUsersFunClubsRepository
    {
        IReadOnlyList<UserFunClub> Get();
        void Add(UserFunClub item);
        void Remove(UserFunClub item);
    }
}