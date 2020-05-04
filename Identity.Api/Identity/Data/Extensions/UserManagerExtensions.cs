using Identity.Api.Identity.Domain.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Data.Managers
{
    public static class UserManagerExtensions
    {
        public async static Task SaveChangesAsync(this UserManager<AppUser> userManager, TransverseIdentityDbContext context)
        {
            await context.SaveChangesAsync();
        }
    }
}
