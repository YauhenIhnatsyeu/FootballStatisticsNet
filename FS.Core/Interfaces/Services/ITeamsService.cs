using FS.Core.Models;

namespace FS.Core.Interfaces.Services
{
    public interface ITeamsService
    {
        Team GetByCode(int code);
    }
}