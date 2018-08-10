using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Core.Interfaces.Services
{
    public interface ILeagueTablesService
    {
        ICollection<LeagueTable> GetByCode(int code);
    }
}