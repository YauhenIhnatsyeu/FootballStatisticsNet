using System;
using System.Collections.Generic;
using System.Text;
using FS.Core.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FS.Core.Interfaces
{
    public interface IFavoriteTeamsRepository
    {
        IReadOnlyList<FavoriteTeam> Get();
        void Add(FavoriteTeam item);
        void Remove(FavoriteTeam item);
    }
}
