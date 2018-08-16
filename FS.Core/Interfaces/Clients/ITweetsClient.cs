using System;
using System.Collections.Generic;
using System.Text;
using FS.Core.Models;
using Newtonsoft.Json.Linq;

namespace FS.Core.Interfaces.Clients
{
    public interface ITweetsClient
    {
        JObject GetByWord(string word);
    }
}
