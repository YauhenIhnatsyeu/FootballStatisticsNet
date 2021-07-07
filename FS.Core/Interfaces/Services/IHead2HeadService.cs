using System;
using System.Collections.Generic;
using System.Text;
using FS.Core.Models;

namespace FS.Core.Interfaces.Services
{
    public interface IHead2HeadService
    {
        Head2Head GetByFixtureCode(int code);
    }
}
