using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Core.Interfaces.Repositories
{
    public interface ILeagueTeamsRepository
    {
        ICollection<Team> GetByCode(int code/*, bool forInitialization = false*/);
    }
}