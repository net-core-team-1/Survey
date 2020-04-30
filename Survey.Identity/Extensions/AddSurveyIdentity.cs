using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Survey.Identity.Data;
using Survey.Identity.Domain.Roles;
using Survey.Identity.Domain.Users;
using System;

namespace Survey.Identity.Extensions
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddSurveyIdentity(this IServiceCollection services)
        {
            
            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<SurveyIdentityContext>()
                    .AddDefaultTokenProviders();
      
            services.AddScoped<IUserStore<User>, UserStore<User, Role, SurveyIdentityContext, Guid, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>>();

            return services;
        }
    }
}
