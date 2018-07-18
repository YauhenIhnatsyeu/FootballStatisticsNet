using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace FS.Core.Interfaces.Repositories
{
    public interface IUsersRepository<T> where T : IdentityUser
    {
        IReadOnlyList<T> Get();
        bool Create(T user, string password);
        T SignIn(T user, string password);
        T FindById(string id);
        T GetLoggedInUser();
    }
}