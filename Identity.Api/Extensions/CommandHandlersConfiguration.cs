using Common.Types.Types.ServiceBus;
using Identity.Api.Contrat.Features.Responses;
using Identity.Api.Contrat.Roles.Responses;
using Identity.Api.Contrat.Users.Responses;
using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Features.Queries;
using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Domain.Roles.Queries;
using Identity.Api.Identity.Domain.Structure.Commands;
using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Domain.Users.Events;
using Identity.Api.Identity.Domain.Users.Queries;
using Identity.Api.Services.AppServices.CommandHandlers;
using Identity.Api.Services.Decorators;
using Identity.Api.Services.Features.CommandHandlers;
using Identity.Api.Services.Features.QueriesHandlers;
using Identity.Api.Services.HandlersDecorators;
using Identity.Api.Services.Roles.CommandHandlers;
using Identity.Api.Services.Roles.Queries;
using Identity.Api.Services.Structures.Commands;
using Identity.Api.Services.Users.CommandHandlers;
using Identity.Api.Services.Users.QuerieHandlers;
using Microsoft.Extensions.DependencyInjection;
using Survey.Common.CQRS.Events;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Extensions.CommandHandlersRegistration
{
    public static class CommandHandlersConfiguration
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRejectedEvent<RegisterUserCommand>, UserRegistrationRejected>();
            services.DecoratorFor<ICommandHandler<RegisterUserCommand>>()
                .Default<RegisterUserCommandHandler>()
                .Envelop((provider, createCustomerHandler) => new RejectedEventOnErrorDecorator<RegisterUserCommand>
                                                                   (createCustomerHandler, provider.GetService<IRejectedEvent<RegisterUserCommand>>(), provider.GetService<IBusPublisher>()))
                .Register();
            services.AddTransient<ICommandHandler<UnregisterUserCommand>, UnregisterUserCommandHandler>();
            services.AddTransient<ICommandHandler<EditUserCommand>, EditUserCommandHandler>();
            services.AddTransient<ICommandHandler<EditUserRolesCommad>, EditUserRolesCommadHandler>();
            services.AddTransient<ICommandHandler<RegisterUserRoleCommand>, RegisterUserRoleCommandHandler>();
            services.AddTransient<ICommandHandler<UnregisterUserRoleCommand>, UnregisterUserRoleCommandHandler>();

            //services.AddTransient<ICommandHandler<EditRoleFeaturesCommand>, EditRoleFeaturesCommandHandler>();

            services.AddTransient<ICommandHandler<RegisterFeatureCommand>, RegisterFeatureCommandHandler>();
            services.AddTransient<ICommandHandler<UnRegisterFeatureCommand>, UnregisterFeatureCommandHandler>();
            services.AddTransient<ICommandHandler<DisableFeatureCommand>, DisableFeatureCommandHandler>();
            services.AddTransient<ICommandHandler<EditFeatureCommand>, EditFeatureCommandHandler>();

            services.AddTransient<ICommandHandler<RegisterRoleCommand>, RegisterRoleCommandHandler>();
            services.AddTransient<ICommandHandler<EditRoleCommand>, EditRoleCommandHandler>();
            services.AddTransient<ICommandHandler<UnregisterRoleCommand>, UnregisterRoleCommandHandler>();
            services.AddTransient<ICommandHandler<DisableRoleCommand>, DisableRoleCommandHandler>();
            services.AddTransient<ICommandHandler<RegisterRoleFeatureCommand>, RegisterRoleFeatureCommandHandler>();

            services.AddTransient<IQueryHandler<GetUserByIdQuery, UserResponse>, GetUserByIdQueryHandler>();
            services.AddTransient<IQueryHandler<GetRolesByUserIdQuery, UserRolesResponse>, GetRolesByUserIdQueryHandler>();
            services.AddTransient<IQueryHandler<GetListFeaturesQuery, List<FeatureListResponse>>, GetListFeaturesQueryHandler>();
            services.AddTransient<IQueryHandler<GetFeatureQuery, FeatureResponse>, GetFeatureQueryHandler>();

            services.AddTransient<IQueryHandler<GetRoleByIdQuery, RoleResponse>, GetRoleByIdQueryHandler>();
            services.AddTransient<IQueryHandler<GetAllRolesQuery, List<RoleListResponse>>, GetAllRolesQueryHandler>();

            services.AddTransient<ICommandHandler<RegisterStructureCommand>, RegisterStructureCommandHandler>();
            services.AddTransient<ICommandHandler<EditStructureCommand>, EditStructureCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteStructureCommand>, DeleteStructureCommandHandler>();
            services.AddTransient<ICommandHandler<DisableStructureCommand>, DisableStructureCommandHandler>();

            services.AddTransient<ICommandHandler<RegisterAppServiceCommand>, RegisterAppServiceCommandHandler>();
            services.AddTransient<ICommandHandler<EditAppServiceCommand>, EditAppServiceCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteAppServiceCommand>, DeleteAppServiceCommandHandler>();
            services.AddTransient<ICommandHandler<DisableAppServiceCommand>, DisableAppServiceCommandHandler>();
            services.AddTransient<ICommandHandler<EditAppServiceFeaturesCommand>, EditAppServiceFeaturesCommandHandler>();
            services.AddTransient<ICommandHandler<EditFeatureAppServiceCommand>, EditFeatureAppServiceCommandHandler>();
        }
    }
}
