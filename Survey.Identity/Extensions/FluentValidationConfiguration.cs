using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Survey.Identity.API.Validations.Authentication;
using Survey.Identity.API.Validations.Features;
using Survey.Identity.Contracts;
using Survey.Identity.Validations.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Extensions
{
    public static class FluentValidationConfiguration
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<SignInRequest>, SignInValidator>();
            services.AddSingleton<IValidator<UserRegistrationRequest>, UserRegistrationValidator>();
            services.AddSingleton<IValidator<UnregisterRequest>, UnregisterValidator>();
            services.AddSingleton<IValidator<EditUserInfoRequest>, EditUserValidator>();

            services.AddSingleton<IValidator<CreateFeatureRequest>, CreateFeatureValidator>();
            services.AddSingleton<IValidator<EditFeatureRequest>, EditFeatureValidator>();
            services.AddSingleton<IValidator<RemoveFeatureRequest>, RemoveFeatureValidator>();


            services.AddSingleton<IValidator<CreateRoleRequest>, CreateRoleValidator>();
            services.AddSingleton<IValidator<EditRoleRequest>, EditRoleValidator>();

            services.AddSingleton<IValidator<RemoveRoleRequest>, RemoveRoleValidator>();
            services.AddSingleton<IValidator<ChangePasswordRequest>, ChangePasswordValidator>();


            return services;
        }
    }
}
