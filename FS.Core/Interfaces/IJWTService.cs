using Microsoft.AspNetCore.Identity;

namespace FS.Core.Interfaces
{
    public interface IJWTService
    {
        string GetToken(IdentityUser userName);
    }
}