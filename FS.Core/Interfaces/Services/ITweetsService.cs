using System.Collections.Generic;
using System.Threading.Tasks;
using FS.Core.Models;

namespace FS.Core.Interfaces.Services
{
    public interface ITweetsService
    {
        ICollection<Tweet> GetByWord(string word);
    }
}