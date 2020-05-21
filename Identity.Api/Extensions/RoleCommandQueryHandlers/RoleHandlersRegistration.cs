using Identity.Api.Contrat.Roles.Responses;
using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Domain.Roles.Events;
using Identity.Api.Identity.Domain.Roles.Events.RejectedEvents;
using Identity.Api.Identity.Domain.Roles.Queries;
using Identity.Api.Services.Decorators;
using Identity.Api.Services.Roles.CommandHandlers;
using Identity.Api.Services.Roles.Queries;
using Microsoft.Extensions.DependencyInjection;
using Survey.Common.CQRS.Events;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Extensions.RoleCommandQueryHandlers
{
    public static class RoleHandlersRegistration
    {
        public static void RegisterRoleCommandQueryHandlers(this IServiceCollection services)
        {
            // Rejected Event registration
            services.AddTransient<IRejectedEvent<DisableRoleCommand>, RoleDisablingRejectedEvent>();
            services.AddTransient<IRejectedEvent<EditRoleCommand>, RoleEditingRejectedEvent>();
            services.AddTransient<IRejectedEvent<EditRoleFeatureCommand>, RoleFeatureEditingRejectedEvent>();
            services.AddTransient<IRejectedEvent<RegisterRoleFeatureCommand>, RoleFeatureRegistrationRejectedEvent>();
            services.AddTransient<IRejectedEvent<UnregisterRoleFeatureCommand>, RoleFeatureUnregistrationRejectedEvent>();
            services.AddTransient<IRejectedEvent<RegisterRoleCommand>, RoleRegistrationRejectedEvent>();
            services.AddTransient<IRejectedEvent<UnregisterRoleCommand>, RoleUnregistrationRejectedEvent>();

            //Accepted Event registration
            services.AddTransient<IAcceptedEvent<DisableRoleCommand>, RoleDisabledEvent>();
            services.AddTransient<IAcceptedEvent<EditRoleCommand>, RoleEditedEvent>();
            services.AddTransient<IAcceptedEvent<EditRoleFeatureCommand>, RoleFeatureEditedEvent>();
            services.AddTransient<IAcceptedEvent<RegisterRoleFeatureCommand>, RoleFeatureRegistredEvent>();
            services.AddTransient<IAcceptedEvent<UnregisterRoleFeatureCommand>, RoleFeatureUnregistredEvent>();
            services.AddTransient<IAcceptedEvent<RegisterRoleCommand>, RoleRegistredEvent>();
            services.AddTransient<IAcceptedEvent<UnregisterRoleCommand>, RoleUnregistredEvent>();

            //Command handlers registration
            services.RegisterWithEventsOnHandling<RegisterRoleCommand, RegisterRoleCommandHandler>();
            services.RegisterWithEventsOnHandling<EditRoleCommand, EditRoleCommandHandler>();
            services.RegisterWithEventsOnHandling<UnregisterRoleCommand, UnregisterRoleCommandHandler>();
            services.RegisterWithEventsOnHandling<DisableRoleCommand, DisableRoleCommandHandler>();
            services.RegisterWithEventsOnHandling<EditRoleFeatureCommand, EditRoleFeatureCommandHandler>();
            services.RegisterWithEventsOnHandling<RegisterRoleFeatureCommand, RegisterRoleFeatureCommandHandler>();
            services.RegisterWithEventsOnHandling<UnregisterRoleFeatureCommand, UnregisterRoleFeatureCommandHandler>();

            // Query handlers registration
            services.AddTransient<IQueryHandler<GetRoleByIdQuery, RoleResponse>, GetRoleByIdQueryHandler>();
            services.AddTransient<IQueryHandler<GetAllRolesQuery, List<RoleListResponse>>, GetAllRolesQueryHandler>();

        }
    }
}
