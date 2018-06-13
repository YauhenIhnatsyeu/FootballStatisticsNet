using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FS.Interfaces
{
    public interface IJWTService
    {
        string GetToken(string userName);
    }
}
