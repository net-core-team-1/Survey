using Identity.Api.Identity.Domain.Authentication.Commands;
using Identity.Api.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Extensions.AuthenticationCommandQueryHandler
{
    public static class AuthenticationHandlers
    {
        public static void RegisterAuthenticationHandlers(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<SignInCommand>, SignInHandler>();
            services.AddTransient<ICommandHandler<SignOutCommand>, LogOutHandler>();
            services.AddTransient<ICommandHandler<ChangePasswordCommand>, ChangePasswordHandler>();
        }
    }
}
