using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Survey.Common.Auth;
using Survey.Identity.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtHandler _jwtHandler;

        public AuthenticationService(UserManager<User> userManager, IJwtHandler jwtHandler)
        {
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }
        public async Task<Result> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return await Task<Result>.FromResult(Result.Failure($"Invalid_credentials"));
            var result = await _userManager.CheckPasswordAsync(user, password);
            if (!result)
                return await Task<Result>.FromResult(Result.Failure($"Invalid_credentials"));


            return await Task<Result>.FromResult(Result.Ok());
        }


        public async Task<Result> ChangePassword(Guid id, string newPassword, string oldPassword)
        {

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return await Task<Result>.FromResult(Result.Failure($"Invalid_credentials"));

            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (!result.Succeeded)
                return await Task<Result>.FromResult(Result.Failure($"Invalid_credentials"));

            return await Task<Result>.FromResult(Result.Ok());
        }


        public async Task<Result> LogOut(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return await Task<Result>.FromResult(Result.Failure($"Invalud_user_id"));
            user.SetLastConnexionDate();

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return await Task<Result>.FromResult(Result.Failure($"User_Could_not_be_updated"));

            return await Task<Result>.FromResult(Result.Ok());
        }

        public async Task<JsonWebToken> IssueWebToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            JsonWebToken token = _jwtHandler.Create(user.Id);
            return token;
        }
    }
}
