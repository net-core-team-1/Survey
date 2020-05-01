using Identity.Api.Identity.Data;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Users;
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
                options.UseSqlServer(configOptions.ConnectionString));

            services.AddIdentityCore<AppUser>()
                .AddEntityFrameworkStores<TransverseIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<IUserStore<AppUser>, UserStore<AppUser, AppRole, TransverseIdentityDbContext, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppUserToken, AppRoleClaim>>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
