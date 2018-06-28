using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FS.Core.Interfaces
{
    public interface IAvatarsRepository
    {
        string Add(string name, Stream stream);
        string Get(string id);
    }
}
