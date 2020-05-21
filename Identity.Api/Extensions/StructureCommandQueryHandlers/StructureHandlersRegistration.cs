using Identity.Api.Contrats.Structures.Responses;
using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Events;
using Identity.Api.Identity.Domain.Structures.Events.RejectedEvents;
using Identity.Api.Identity.Domain.Structures.Queries;
using Identity.Api.Services.Decorators;
using Identity.Api.Services.Structures.Commands;
using Identity.Api.Services.Structures.QueryHandlers;
using Microsoft.Extensions.DependencyInjection;
using Survey.Common.CQRS.Events;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Extensions.StructureCommandQueryHandlers
{
    public static class StructureHandlersRegistration
    {
        public static void RegisterStructureCommandQueryHandlers(this IServiceCollection services)
        {
            // Rejected Event registration
            services.AddTransient<IRejectedEvent<DeleteStructureCommand>, StructureDeletingRejectedEvent>();
            services.AddTransient<IRejectedEvent<DisableStructureCommand>, StructureDisablingRejectedEvent>();
            services.AddTransient<IRejectedEvent<EditStructureCommand>, StructureEditionRejectedEvent>();
            services.AddTransient<IRejectedEvent<RegisterStructureCommand>, StructureRegistrationRejectedEvent>();
            services.AddTransient<IRejectedEvent<EditStructureUsersCommand>, StructureUsersEditionRejectedEvent>();
            services.AddTransient<IRejectedEvent<RegisterStructureUserCommand>, StructureUsersRegistrationRejectedEvent>();
            services.AddTransient<IRejectedEvent<UnregisterStructureUserCommand>, StructureUsersUnregistrationRejectedEvent>();

            //Accepted Event registration
            services.AddTransient<IAcceptedEvent<DeleteStructureCommand>, StructureDeletedEvent>();
            services.AddTransient<IAcceptedEvent<DisableStructureCommand>, StructureDisabledEvent>();
            services.AddTransient<IAcceptedEvent<EditStructureCommand>, StructureEditedEvent>();
            services.AddTransient<IAcceptedEvent<RegisterStructureCommand>, StructureRegistredEvent>();
            services.AddTransient<IAcceptedEvent<EditStructureUsersCommand>, StructureUsersEditedEvent>();
            services.AddTransient<IAcceptedEvent<RegisterStructureUserCommand>, StructureUsersRegistredEvent>();
            services.AddTransient<IAcceptedEvent<UnregisterStructureUserCommand>, StructureUsersUnregistredEvent>();

            // Command handlers registration
            services.RegisterWithEventsOnHandling<RegisterStructureCommand, RegisterStructureCommandHandler>();
            services.RegisterWithEventsOnHandling<EditStructureCommand, EditStructureCommandHandler>();
            services.RegisterWithEventsOnHandling<DeleteStructureCommand, DeleteStructureCommandHandler>();
            services.RegisterWithEventsOnHandling<DisableStructureCommand, DisableStructureCommandHandler>();
            services.RegisterWithEventsOnHandling<EditStructureUsersCommand, EditStructureUsersCommandHandler>();
            services.RegisterWithEventsOnHandling<RegisterStructureUserCommand, RegisterStructureUserCommandHandler>();
            services.RegisterWithEventsOnHandling<UnregisterStructureUserCommand, UnregisterStructureUserCommandHandler>();

            // Query handlers registration
            services.AddTransient<IQueryHandler<GetStructureByIdQuery, StructureResponse>, GetStructureByIdQueryHandler>();
            services.AddTransient<IQueryHandler<GetStructureListQuery, StructureListResponse>, GetStructureListQueryHandler>();
            services.AddTransient<IQueryHandler<GetStructureUsersQuery, StructureUserResponse>, GetStructureUsersQueryHandler>();
        }
    }
}
