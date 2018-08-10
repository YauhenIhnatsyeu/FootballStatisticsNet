using FS.Core.Models;

namespace FS.Core.Interfaces.Repositories
{
    public interface ITeamsRepository
    {
        Team GetByCode(int code);
    }
}