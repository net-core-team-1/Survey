using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Data;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
        private readonly TransverseIdentityDbContext _transverseIdentityDbContext;

        public UserService(UserManager<AppUser> userManager, TransverseIdentityDbContext transverseIdentityDbContext)
        {
            _userManager = userManager;
            _transverseIdentityDbContext = transverseIdentityDbContext;
        }

        public async Task<AppUser> FindUserByUserNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<IdentityResult> RegisterNewAsync(AppUser user, UserPassword password)
        {
            try
            {
                _transverseIdentityDbContext.Attach(user);
                return await _userManager.CreateAsync(user, password.Value);
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

        public async Task<Result> AssignRolesAsync(AppUser user, IEnumerable<AppRole> roles)
        {
            try
            {
                var result = await _userManager.AddToRolesAsync(user, roles.Select(x => x.Name).ToList());
                if (!result.Succeeded)
                    return Result.Failure("User could not be saved");

                return Result.Ok();
            }
            catch (Exception ex)
            {
                throw new IdentityException(ex, "USER_ASSIGN_ROLES_FAILED", ex.Message);
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
    }
}
