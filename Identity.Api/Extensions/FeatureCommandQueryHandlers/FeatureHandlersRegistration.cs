using Identity.Api.Contrat.Features.Responses;
using Identity.Api.Contrats.Features.Responses;
using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Features.Events;
using Identity.Api.Identity.Domain.Features.Events.RejectedEvents;
using Identity.Api.Identity.Domain.Features.Queries;
using Identity.Api.Services.Decorators;
using Identity.Api.Services.Features.CommandHandlers;
using Identity.Api.Services.Features.QueriesHandlers;
using Microsoft.Extensions.DependencyInjection;
using Survey.Common.CQRS.Events;
using Survey.Common.Types;

namespace Identity.Api.Extensions.FeatureCommandQueryHandlers
{
    public static class FeatureHandlersRegistration
    {
        public static void RegisterFeatureCommandQueryHandlers(this IServiceCollection services)
        {
            // Rejected Event registration
            services.AddTransient<IRejectedEvent<EditFeatureAppServiceCommand>, FeatureAppServiceEditingRejectedEvent>();
            services.AddTransient<IRejectedEvent<DisableFeatureCommand>, FeatureDisablingRejectedEvent>();
            services.AddTransient<IRejectedEvent<EditFeatureCommand>, FeatureEditingRejectedEvent>();
            services.AddTransient<IRejectedEvent<RegisterFeatureCommand>, FeatureRegistrationRejectedEvent>();
            services.AddTransient<IRejectedEvent<UnRegisterFeatureCommand>, FeatureUnregistrationRejectedEvent>();

            //Accepted Event registration
            services.AddTransient<IAcceptedEvent<EditFeatureAppServiceCommand>, FeatureAppServiceEditedEvent>();
            services.AddTransient<IAcceptedEvent<DisableFeatureCommand>, FeatureDisabledEvent>();
            services.AddTransient<IAcceptedEvent<EditFeatureCommand>, FeatureEditedEvent>();
            services.AddTransient<IAcceptedEvent<RegisterFeatureCommand>, FeatureRegistredEvent>();
            services.AddTransient<IAcceptedEvent<UnRegisterFeatureCommand>, FeatureUnregistredEvent>();

            // Command handlers registration
            services.RegisterWithEventsOnHandling<RegisterFeatureCommand, RegisterFeatureCommandHandler>();
            services.RegisterWithEventsOnHandling<UnRegisterFeatureCommand, UnregisterFeatureCommandHandler>();
            services.RegisterWithEventsOnHandling<DisableFeatureCommand, DisableFeatureCommandHandler>();
            services.RegisterWithEventsOnHandling<EditFeatureCommand, EditFeatureCommandHandler>();
            services.RegisterWithEventsOnHandling<EditFeatureAppServiceCommand, EditFeatureAppServiceCommandHandler>();

            // Query handlers registration
            services.AddTransient<IQueryHandler<GetListFeaturesQuery, FeaturesListResponse>, GetListFeaturesQueryHandler>();
            services.AddTransient<IQueryHandler<GetFeatureQuery, FeatureResponse>, GetFeatureQueryHandler>();
            services.AddTransient<IQueryHandler<GetListFeaturesByServiceQuery, FeaturesListResponse>, GetListFeatureByServiceHandler>();
            services.AddTransient<IQueryHandler<GetListFeaturesByRoleIdQuery, FeaturesListResponse>, GetListFeaturesByRoleIdQueryHandler>();

        }
    }
}
