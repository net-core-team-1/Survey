﻿using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Domain.Users.Events;
using Identity.Api.Identity.Domain.Users.Events.RejectedEvents;
using Identity.Api.Services.Decorators;
using Identity.Api.Services.Users.CommandHandlers;
using Microsoft.Extensions.DependencyInjection;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Extensions.UserCommandQueryHandlers
{
    public static class UserHandlersRegistration
    {
        public static void RegisterUserCommandQueryHandlers(this IServiceCollection services)
        {
            // Rejected Events registration
            services.AddTransient<IRejectedEvent<RegisterUserCommand>, UserRegistrationRejectedEvent>();
            services.AddTransient<IRejectedEvent<EditUserCommand>, UserEditionRejectedEvent>();
            services.AddTransient<IRejectedEvent<UnregisterUserCommand>, UserUnregistrationRejectedEvent>();
            services.AddTransient<IRejectedEvent<RegisterUserRoleCommand>, UserRoleRegistrationsRejectedEvent>();
            services.AddTransient<IRejectedEvent<EditUserRolesCommad>, UserRolesEditionRejectedEvent>();
            services.AddTransient<IRejectedEvent<UnregisterUserRoleCommand>, UserRoleUnregistrationRejectedEvent>();

            // Acceppted Events registration
            services.AddTransient<IAcceptedEvent<RegisterUserCommand>, UserRegistredEvent>();
            services.AddTransient<IAcceptedEvent<EditUserCommand>, UserEditedEvent>();
            services.AddTransient<IAcceptedEvent<UnregisterUserCommand>, UserUnregistredEvent>();
            services.AddTransient<IAcceptedEvent<RegisterUserRoleCommand>, UserRoleRegistredEvent>();
            services.AddTransient<IAcceptedEvent<EditUserRolesCommad>, UserRolesEditedEvent>();
            services.AddTransient<IAcceptedEvent<UnregisterUserRoleCommand>, UserRoleUnregistredEvent>();

            // User Command handlers registration
            services.RegisterWithEventsOnHandling<RegisterUserCommand, RegisterUserCommandHandler>();
            services.RegisterWithEventsOnHandling<UnregisterUserCommand, UnregisterUserCommandHandler>();
            services.RegisterWithEventsOnHandling<EditUserCommand, EditUserCommandHandler>();
            services.RegisterWithEventsOnHandling<EditUserRolesCommad, EditUserRolesCommadHandler>();
            services.RegisterWithEventsOnHandling<RegisterUserRoleCommand, RegisterUserRoleCommandHandler>();
            services.RegisterWithEventsOnHandling<UnregisterUserRoleCommand, UnregisterUserRoleCommandHandler>();
        }
    }
}