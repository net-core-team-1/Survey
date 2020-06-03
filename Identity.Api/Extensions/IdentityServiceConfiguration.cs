using Identity.Api.Data;
using Identity.Api.Data.Stores;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Users;
using Identity.Api.Identity.Services.Roles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Survey.Identity.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Extensions.IdentityServiceRegistration
{
    public static class IdentityServiceConfiguration
    {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            var configOptions = new TransversIdentityOptions();
            configuration.GetSection("SurveyIdentity").Bind(configOptions);

            services.AddDbContext<TransverseIdentityDbContext>(options =>
                options.UseSqlServer(configOptions.ConnectionString).UseLazyLoadingProxies(),ServiceLifetime.Scoped)
               ;

            services
                .AddIdentityCore<AppUser>()
                .AddRoles<AppRole>()
                .AddEntityFrameworkStores<TransverseIdentityDbContext>()
                .AddDefaultTokenProviders()
                .AddUserStore<AppUserStore>()
                .AddRoleStore<AppRoleStore>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<IUserService, UserService>(sp =>
            {
                return new UserService(sp.GetRequiredService<UserManager<AppUser>>());
            });
            services.AddScoped<IRoleService, RoleService>(sp =>
            {
                return new RoleService(sp.GetRequiredService<RoleManager<AppRole>>());
            });
        }
    }
}
