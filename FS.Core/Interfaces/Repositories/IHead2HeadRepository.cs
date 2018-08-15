using System;
using System.Collections.Generic;
using System.Text;
using FS.Core.Models;

namespace FS.Core.Interfaces.Repositories
{
    public interface IHead2HeadRepository
    {
        Head2Head GetByFixtureCode(int code);
    }
}
