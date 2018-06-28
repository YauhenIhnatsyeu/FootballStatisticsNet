using Microsoft.AspNetCore.Identity;

namespace FS.Core.Interfaces.Services
{
    public interface IJWTService
    {
        string GetToken(IdentityUser userName);
    }
}