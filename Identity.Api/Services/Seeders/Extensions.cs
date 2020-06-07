using Identity.Api.Services.Seeders.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders
{
    public static class Extensions
    {
        public static void RegisterSeeders(this IServiceCollection services)
        {
            services.AddSingleton<IRootStructureSeeder, RootStructureSeeder>();
            services.AddSingleton<IRootUserSeeder, RootUserSeeder>();
            services.AddSingleton<IRootAppServiceSeeder, RootAppServiceSeeder>();
            services.AddSingleton<IRootRoleSeeder, RootRoleSeeder>();
            services.AddSingleton<IFeatureSeeder, FeaturesSeeder>();
            services.AddSingleton<IRoleFeatureSeeder, RoleFeatureSeeder>();
            services.AddSingleton<IUserSeeder, UsersSeeder>();
            services.AddSingleton<ICivilitySeeder, CivilitySeeder>();
        }
    }
}
