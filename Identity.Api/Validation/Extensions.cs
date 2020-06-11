using FluentValidation;
using Identity.Api.Contrat.AppServices.Requests;
using Identity.Api.Contrat.Features.Requests;
using Identity.Api.Contrat.Roles.Requests;
using Identity.Api.Contrat.Structures.Requests;
using Identity.Api.Contrat.Users.Requests;
using Identity.Api.Contrats.Roles.Requests;
using Identity.Api.Contrats.Structures.Requests;
using Identity.Api.Contrats.Users.Requests;
using Identity.Api.Validation.AppService;
using Identity.Api.Validation.Feature;
using Identity.Api.Validation.Role;
using Identity.Api.Validation.Structure;
using Identity.Api.Validation.User;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation
{
    public static class Extensions
    {
        public static void AddFluentValidations(this IServiceCollection services)
        {

            services.AddSingleton<IValidator<RegisterAppServiceRequest>, RegisterAppServiceValidator>();
            services.AddSingleton<IValidator<EditAppServiceRequest>, EditAppServiceValidator>();
            services.AddSingleton<IValidator<DisableAppServiceRequest>, DisableAppServiceValidator>();
            services.AddSingleton<IValidator<DeleteAppServiceRequest>, DeleteAppServiceValidator>();
            services.AddSingleton<IValidator<RegisterAppServiceFeatureRequest>, RegisterAppServiceFeatureValidator>();
            services.AddSingleton<IValidator<EditAppServiceFeaturesRequest>, EditAppServiceFeaturesValidator>();

            services.AddSingleton<IValidator<DisableFeatureRequest>, DisableFeatureValidator>();
            services.AddSingleton<IValidator<EditFeatureRequest>, EditFeatureValidator>();
            services.AddSingleton<IValidator<RegisterFeatureRequest>, RegisterFeatureValidator>();
            services.AddSingleton<IValidator<UnregisterFeatureRequest>, UnregisterFeatureValidator>();

            services.AddSingleton<IValidator<DisableRoleRequest>, DisableRoleValidator>();
            services.AddSingleton<IValidator<EditRoleFeatureRequest>, EditRoleFeatureValidator>();
            services.AddSingleton<IValidator<EditRoleRequest>, EditRoleValidator>();
            services.AddSingleton<IValidator<RegisterRoleFeatureRequest>, RegisterRoleFeatureValidator>();
            services.AddSingleton<IValidator<RegisterRoleRequest>, RegisterRoleValidator>();
            services.AddSingleton<IValidator<UnregisterRoleFeatureRequest>, UnregisterRoleFeatureValidator>();
            services.AddSingleton<IValidator<UnregisterRoleRequest>, UnregisterRoleValidator>();

            services.AddSingleton<IValidator<DeleteStructureRequest>, DeleteStructureValidator>();
            services.AddSingleton<IValidator<DisableStructureRequest>, DisableStructureValidator>();
            services.AddSingleton<IValidator<EditStructureUsersRequest>, EditStructureUsersValidator>();
            services.AddSingleton<IValidator<EditStructureRequest>, EditStructureValidator>();
            services.AddSingleton<IValidator<EditStructureUsersRequest>, EditStructureUsersValidator>();
            services.AddSingleton<IValidator<DisableStructureRequest>, DisableStructureValidator>();
            services.AddSingleton<IValidator<DeleteStructureRequest>, DeleteStructureValidator>();

            services.AddSingleton<IValidator<EditUserRequest>, EditUserValidator>();
            services.AddSingleton<IValidator<EditUserRolesRequest>, EditUserRolesValidator>();
            services.AddSingleton<IValidator<RegisterUserRoleRequest>, RegisterUserRoleValidator>();
            services.AddSingleton<IValidator<RegisterUserRequest>, RegisterUserValidator>();
            services.AddSingleton<IValidator<UnregisterUserRoleRequest>, UnregisterUserRoleValidator>();
            services.AddSingleton<IValidator<UnregisterUserRequest>, UnregisterUserValidator>();
        }
    }
}
