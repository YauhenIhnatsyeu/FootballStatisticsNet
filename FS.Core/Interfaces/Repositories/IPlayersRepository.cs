using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Core.Interfaces.Repositories
{
    public interface IPlayersRepository
    {
        ICollection<Player> GetByTeamCode(int code);
    }
}