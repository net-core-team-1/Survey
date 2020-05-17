using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Data;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.Civilities;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Users;
using Identity.Api.Identity.Services.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUser> FindUserByUserNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<IdentityResult> RegisterNewAsync(AppUser user, UserPassword password)
        {
            try
            {
                var result = await _userManager.CreateAsync(user, password.Value);
                return result;
            }
            catch (Exception ex)
            {
                throw new IdentityException(ex, "USER_REGISTRATION_FAILED", ex.Message);

            }
        }
        public async Task<Result> AssignRoleAsync(AppUser user, AppRole role)
        {
            try
            {
                var result = await _userManager.AddToRoleAsync(user, role.Name);
                if (!result.Succeeded)
                    return Result.Failure("User could not be saved");

                return Result.Ok();
            }
            catch (Exception ex)
            {
                throw new IdentityException(ex, "USER_ASSIGN_ROLE_FAILED", ex.Message);
            }
        }
        public async Task<bool> ValidatePassword(AppUser user, string password)
        {
            try
            {
                return await _userManager.CheckPasswordAsync(user, password);
            }
            catch (Exception ex)
            {
                throw new IdentityException(ex, "USER_PASSWORD_VALIDATION_FAILED", ex.Message);
            }
        }

        public async Task<IdentityResult> UpdateAsync(AppUser user)
        {
            try
            {
                var result = await _userManager.UpdateAsync(user);
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                throw new IdentityException(ex, "UNREGISTER_USER_FAILED", ex.Message);
            }
        }

        public async Task<AppUser> FindUserByUserIdAsync(Guid userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }
        public async Task<List<AppUser>> FindRoleByIdsAsync(List<Guid> userIds)
        {
            var result = _userManager.Users
                                     .Where(x => userIds.Contains(x.Id))
                                     .ToList();

            return await Task.FromResult(result);
        }

        public async Task<Result> AssignRolesAsync(Guid userId, List<Guid> roles)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new IdentityException("USER_NOT_FOUND", "User not found in database");
            user.EditRoles(roles);

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return Result.Failure("User could not be saved");

            return Result.Ok();
        }

    }
}
