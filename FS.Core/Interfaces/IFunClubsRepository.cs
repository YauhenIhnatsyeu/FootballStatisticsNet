using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Core.Interfaces
{
    public interface IFunClubsRepository
    {
        IReadOnlyList<FunClub> Get();
        void Add(FunClub item);
        void Remove(FunClub item);
    }
}