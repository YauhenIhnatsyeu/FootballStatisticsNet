using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Core.Interfaces.Repositories
{
    public interface IFavoriteTeamsRepository
    {
        IReadOnlyList<FavoriteTeam> Get();
        FavoriteTeam GetByUserAndTeam(User user, Team team);
        void Add(FavoriteTeam item);
        void Remove(FavoriteTeam item);
    }
}