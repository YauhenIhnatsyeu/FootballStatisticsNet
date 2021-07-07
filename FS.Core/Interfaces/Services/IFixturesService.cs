using System;
using System.Collections.Generic;
using FS.Core.Models;

namespace FS.Core.Interfaces.Services
{
    public interface IFixturesService
    {
        ICollection<Fixture> GetByTeamIdAndDates(int code, DateTime fromDate, DateTime toDate);
    }
}
