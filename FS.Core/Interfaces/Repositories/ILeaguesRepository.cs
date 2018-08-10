using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Core.Interfaces.Repositories
{
    public interface ILeaguesRepository
    {
        ICollection<LeagueTeam> GetByCode(int code);
    }
}