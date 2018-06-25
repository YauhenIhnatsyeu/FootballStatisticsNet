using System;
using System.Collections.Generic;
using System.Text;
using FS.Core.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FS.Core.Interfaces
{
    public interface ITeamsRepository
    {
        IReadOnlyList<Team> Get();
        void Add(Team item);
        void Remove(Team item);
    }
}
