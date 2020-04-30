using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Survey.Identity.Domain;
using Survey.Identity.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public Task<Result> RegisterUser(string firstName, string lastName, string email, string password, List<Guid> roles)
        {
            var user = _userManager.FindByEmailAsync(email);
            if (user == null)
                return Task<Result>.FromResult(Result.Failure($"Email already in use invalid "));

            Result<FullName> fullNameResult = FullName.Create(firstName, lastName);
            if (fullNameResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure($"FirstName/LastName invalid "));

            var newUser = new User(fullNameResult.Value, email, roles);

            var result = _userManager.CreateAsync(newUser, password);
            if (!result.Result.Succeeded)
                return Task<Result>.FromResult(Result.Failure("User could not be saved"));

            return Task<Result>.FromResult(Result.Ok());

        }


        public async Task<Result> ChangeEmail(Guid userId, string email)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return await Task<Result>.FromResult(Result.Failure($"User_not_exist "));
            string token = await _userManager.GenerateChangeEmailTokenAsync(user, email);
            var result = await _userManager.ChangeEmailAsync(user, email, token);

            if (!result.Succeeded)
                return await Task<Result>.FromResult(Result.Failure("User could not be saved"));

            return await Task<Result>.FromResult(Result.Ok());
        }

        public async Task<Result> EditInfo(Guid userId, string firstName, string lastName, List<Guid> roles = null, bool deleteExisting = false)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return await Task<Result>.FromResult(Result.Failure($"User_not_exist "));

            Result<FullName> fullNameResult = FullName.Create(firstName, lastName);
            if (fullNameResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure($"FirstName/LastName invalid "));

            user.EditUser(fullNameResult.Value, roles, deleteExisting);

            var result = _userManager.UpdateAsync(user);
            if (!result.Result.Succeeded)
                return await Task<Result>.FromResult(Result.Failure("User could not be saved"));

            return await Task<Result>.FromResult(Result.Ok());
        }


        public async Task<Result> UnregisterUser(Guid userId, Guid by, string reason)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return await Task<Result>.FromResult(Result.Failure($"No user found for Id= {userId}"));

            Result<DeleteInfo> deletionResult = DeleteInfo.Create(by, reason);
            if (deletionResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure($"Deletion reason error"));

            user.Unregister(deletionResult.Value);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return await Task<Result>.FromResult(Result.Failure("User could not be unregistred"));
            }
            return await Task<Result>.FromResult(Result.Ok());
        }
    }
}
