using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FS.Models;

namespace FS.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateAsync(User user, string password);
        Task<bool> SignInAsync(string userName, string password);
        Task<bool> SignInAsync(string userName, string password, out string token);
    }
}
