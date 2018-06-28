using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Core.Interfaces.Repositories
{
    public interface ITeamsRepository
    {
        IReadOnlyList<Team> Get();
        Team GetByTeam(Team item);
        void Add(Team item);
        void Remove(Team item);
        bool Contains(Team item);
    }
}