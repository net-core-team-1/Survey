using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Data;
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
        private readonly RoleManager<AppUser> _roleManager;
        private readonly TransverseIdentityDbContext _transverseIdentityDbContext;

        public RoleService(RoleManager<AppUser> roleManager, TransverseIdentityDbContext transverseIdentityDbContext)
        {
            _roleManager = roleManager;
            _transverseIdentityDbContext = transverseIdentityDbContext;
        }

        //public async Task<List<Guid>> GetRoleIds(List<AppRole> roles)
        //{
        //    List<Guid> roleIds = new List<Guid>();
        //    foreach (var item in roles)
        //    {
        //        var result = await _roleManager.edit
        //    }
           
        //}
    }
}
