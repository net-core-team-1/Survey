using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Data;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public Task<AppRole> FindRoleById(Guid roleId)
        {
            return _roleManager.FindByIdAsync(roleId.ToString());
        }
        public async Task<IdentityResult> RegisterNewAsync(AppRole role)
        {
            try
            {
                var result = await _roleManager.CreateAsync(role);
                return result;
            }
            catch (Exception ex)
            {
                throw new IdentityException(ex, "ROLE_REGISTRATION_FAILED", ex.Message);

            }
        }

        public async Task<IdentityResult> UpdateAsync(AppRole role)
        {
            try
            {
                var result = await _roleManager.UpdateAsync(role);
                return result;
            }
            catch (Exception ex)
            {
                throw new IdentityException(ex, "ROLE_REGISTRATION_FAILED", ex.Message);
            }
        }

        public async Task<IdentityResult> DeleteAsync(AppRole role)
        {
            try
            {
                var result = await _roleManager.DeleteAsync(role);
                return result;
            }
            catch (Exception ex)
            {
                throw new IdentityException(ex, "ROLE_REGISTRATION_FAILED", ex.Message);

            }
        }

        public Task<List<AppRole>> FindRoleByIds(List<Guid> roleIds)
        {
            return Task.FromResult(_roleManager.Roles.
                                        Where(x => roleIds.Contains(x.Id))
                                        .ToList());
        }

        public Task<AppRole> FindRoleByName(string roleName)
        {
            return _roleManager.FindByNameAsync(roleName);
        }
    }
}
