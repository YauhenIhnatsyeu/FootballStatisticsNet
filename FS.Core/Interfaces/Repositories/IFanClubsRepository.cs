using System;
using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Core.Interfaces.Repositories
{
    public interface IFanClubsRepository
    {
        IReadOnlyList<FanClub> Get();
        void Add(FanClub item);
        void Remove(FanClub item);
        FanClub FindById(int id);
    }
}