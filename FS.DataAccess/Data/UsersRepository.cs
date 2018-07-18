using System.Collections.Generic;
using System.Linq;
using FS.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FS.DataAccess.Data
{
    public class UsersRepository<T> : IUsersRepository<T> where T : IdentityUser
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly SignInManager<T> signInManager;
        private readonly UserManager<T> userManager;

        public UsersRepository(
            UserManager<T> userManager,
            SignInManager<T> signInManager,
            IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IReadOnlyList<T> Get()
        {
            return userManager.Users.ToList();
        }

        public bool Create(T user, string password)
        {
            return userManager.CreateAsync(user, password).Result.Succeeded;
        }

        public T SignIn(T user, string password)
        {
            return signInManager.PasswordSignInAsync(user.UserName, password, false, false).Result.Succeeded
                ? FindByName(user.UserName)
                : null;
        }

        public T FindById(string id)
        {
            return userManager.FindByIdAsync(id).Result;
        }

        public T GetLoggedInUser()
        {
            string userName = httpContextAccessor.HttpContext.User.Identity.Name;
            return FindByName(userName);
        }

        private T FindByName(string name)
        {
            return userManager.FindByNameAsync(name).Result;
        }
    }
}