using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Core.Interfaces.Repositories
{
    public interface ILeagueTablesRepository
    {
        ICollection<LeagueTable> GetByCode(int code);
    }
}