using System;
using System.Threading.Tasks;
using FS.Interfaces;
using FS.Models;
using Microsoft.AspNetCore.Identity;

namespace FS.Services
{
    public class UserService : IUserService
    {
        private readonly IJWTService jwtService;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IJWTService jwtService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtService = jwtService;
        }

        public async Task<bool> CreateAsync(User user, string password) {
            var createResult = await userManager.CreateAsync(user, password);
            return createResult.Succeeded;
        }

        public async Task<bool> SignInAsync(string userName, string password)
        {
            var signInResult = await signInManager.PasswordSignInAsync(userName, password, false, false);
            return signInResult.Succeeded;
        }

        public Task<bool> SignInAsync(string userName, string password, out string token)
        {
            var signInResult = SignInAsync(userName, password);
            token = signInResult.Result
                ? jwtService.GetToken(userName)
                : null;
            return signInResult;
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return userManager.FindByNameAsync(userName);
        }
    }
}