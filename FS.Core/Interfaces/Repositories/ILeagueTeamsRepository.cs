using System;
using System.Collections.Generic;
using System.Text;
using FS.Core.Models;

namespace FS.Core.Interfaces.Repositories
{
    public interface ILeagueTeamsRepository
    {
        ICollection<Team> GetByCode(int code);
    }
}
