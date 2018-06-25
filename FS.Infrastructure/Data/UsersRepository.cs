using FS.Core.Interfaces;
using FS.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace FS.Infrastructure.Data
{
    public class UsersRepository<T> : IUsersRepository<T> where T : IdentityUser
    {
        private readonly SignInManager<T> signInManager;
        private readonly UserManager<T> userManager;

        public UsersRepository(UserManager<T> userManager, SignInManager<T> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public bool Create(T user, string password)
        {
            return userManager.CreateAsync(user, password).Result.Succeeded;
        }

        public bool SignIn(T user, string password)
        {
            return signInManager.PasswordSignInAsync(user.UserName, password, false, false)
                .Result.Succeeded;
        }

        public T FindByName(string name)
        {
            return userManager.FindByNameAsync(name).Result;
        }
    }
}