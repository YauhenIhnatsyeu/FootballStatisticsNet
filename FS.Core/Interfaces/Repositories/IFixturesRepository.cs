using System;
using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Core.Interfaces.Repositories
{
    public interface IFixturesRepository
    {
        ICollection<Fixture> GetByTeamIdAndDates(int code, DateTime fromDate, DateTime toDate);
    }
}
