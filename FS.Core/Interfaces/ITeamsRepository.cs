using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Core.Interfaces
{
    public interface ITeamsRepository
    {
        IReadOnlyList<Team> Get();
        void Add(Team item);
        void Remove(Team item);
    }
}