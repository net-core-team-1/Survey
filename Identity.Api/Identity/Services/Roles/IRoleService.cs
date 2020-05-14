using CSharpFunctionalExtensions;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Services.Roles
{
    public interface IRoleService
    {
        Task<AppRole> FindRoleById(Guid roleId);
        Task<List<AppRole>> FindRoleByIds(List<Guid> roleIds);
        Task<IdentityResult> RegisterNewAsync(AppRole role);
        Task<IdentityResult> UpdateAsync(AppRole role);
        Task<IdentityResult> DeleteAsync(AppRole role);
    }
}
