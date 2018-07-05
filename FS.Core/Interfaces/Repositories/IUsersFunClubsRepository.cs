using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Core.Interfaces.Repositories
{
    public interface IUsersFanClubsRepository
    {
        IReadOnlyList<UserFanClub> Get();
        UserFanClub GetByUserFanClub(UserFanClub userFanClub);
        void Add(UserFanClub item);
        void Remove(UserFanClub item);
        void Update(UserFanClub source);
    }
}