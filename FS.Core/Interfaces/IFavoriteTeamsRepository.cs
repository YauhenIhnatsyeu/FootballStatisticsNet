using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Core.Interfaces
{
    public interface IFavoriteTeamsRepository
    {
        IReadOnlyList<FavoriteTeam> Get();
        void Add(FavoriteTeam item);
        void Remove(FavoriteTeam item);
    }
}