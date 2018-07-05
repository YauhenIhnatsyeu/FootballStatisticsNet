using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Core.Interfaces.Repositories
{
    public interface IUsersFunClubsRepository
    {
        IReadOnlyList<UserFunClub> Get();
        UserFunClub GetByUserFunClub(UserFunClub userFunClub);
        void Add(UserFunClub item);
        void Remove(UserFunClub item);
        void Update(UserFunClub source);
    }
}