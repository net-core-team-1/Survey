﻿using CSharpFunctionalExtensions;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Users
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterNewAsync(AppUser user, UserPassword password);
        Task<AppUser> FindUserByUserNameAsync(string userName);
        Task<bool> ValidatePassword(AppUser user, string password);
        Task<Result> AssignRoleAsync(AppUser user, AppRole role);
        Task<Result> AssignRolesAsync(AppUser user, IEnumerable<AppRole> roles);
    }
}
