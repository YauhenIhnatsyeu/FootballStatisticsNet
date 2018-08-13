using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Core.Interfaces.Services
{
    public interface IPlayersService
    {
        ICollection<Player> GetByTeamCode(int code);
    }
}