using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace FS.Core.Interfaces
{
    public interface IUsersRepository<T> where T : IdentityUser
    {
        bool Create(T user, string password);
        bool SignIn(T user, string password);
        T FindByName(string name);
    }
}
