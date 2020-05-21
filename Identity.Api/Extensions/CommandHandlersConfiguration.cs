using Common.Types.Types.ServiceBus;
using Identity.Api.Contrat.Features.Responses;
using Identity.Api.Contrat.Roles.Responses;
using Identity.Api.Contrat.Users.Responses;
using Identity.Api.Contrats.Features.Responses;
using Identity.Api.Contrats.Structures.Responses;
using Identity.Api.Contrats.Users.Responses.UserInfo;
using Identity.Api.Contrats.Users.Responses.UserStructures;
using Identity.Api.Extensions.RoleCommandQueryHandlers;
using Identity.Api.Extensions.UserCommandQueryHandlers;
using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Features.Queries;
using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Domain.Roles.Events;
using Identity.Api.Identity.Domain.Roles.Events.RejectedEvents;
using Identity.Api.Identity.Domain.Roles.Queries;
using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Queries;
using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Domain.Users.Events;
using Identity.Api.Identity.Domain.Users.Events.RejectedEvents;
using Identity.Api.Identity.Domain.Users.Queries;
using Identity.Api.Services.AppServices.CommandHandlers;
using Identity.Api.Services.Decorators;
using Identity.Api.Services.Features.CommandHandlers;
using Identity.Api.Services.Features.QueriesHandlers;
using Identity.Api.Services.HandlersDecorators;
using Identity.Api.Services.Roles.CommandHandlers;
using Identity.Api.Services.Roles.Queries;
using Identity.Api.Services.Structures.Commands;
using Identity.Api.Services.Structures.QueryHandlers;
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
            services.RegisterUserCommandQueryHandlers();
            services.RegisterRoleCommandQueryHandlers();


            services.AddTransient<ICommandHandler<RegisterFeatureCommand>, RegisterFeatureCommandHandler>();
            services.AddTransient<ICommandHandler<UnRegisterFeatureCommand>, UnregisterFeatureCommandHandler>();
            services.AddTransient<ICommandHandler<DisableFeatureCommand>, DisableFeatureCommandHandler>();
            services.AddTransient<ICommandHandler<EditFeatureCommand>, EditFeatureCommandHandler>();

            services.AddTransient<IQueryHandler<GetListFeaturesQuery, FeaturesListResponse>, GetListFeaturesQueryHandler>();
            services.AddTransient<IQueryHandler<GetFeatureQuery, FeatureResponse>, GetFeatureQueryHandler>();
            services.AddTransient<IQueryHandler<GetListFeaturesByServiceQuery, FeaturesListResponse>, GetListFeatureByServiceHandler>();
            services.AddTransient<IQueryHandler<GetListFeaturesByRoleIdQuery, FeaturesListResponse>, GetListFeaturesByRoleIdQueryHandler>();
            services.AddTransient<IQueryHandler<GetUserStructuresById, UserStructureResponse>, GetUserStructuresByIdHandler>();


            services.AddTransient<ICommandHandler<RegisterStructureCommand>, RegisterStructureCommandHandler>();
            services.AddTransient<ICommandHandler<EditStructureCommand>, EditStructureCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteStructureCommand>, DeleteStructureCommandHandler>();
            services.AddTransient<ICommandHandler<DisableStructureCommand>, DisableStructureCommandHandler>();
            services.AddTransient<ICommandHandler<EditStructureUsersCommand>, EditStructureUsersCommandHandler>();
            services.AddTransient<ICommandHandler<RegisterStructureUserCommand>, RegisterStructureUserCommandHandler>();
            services.AddTransient<ICommandHandler<UnregisterStructureUserCommand>, UnregisterStructureUserCommandHandler>();
            services.AddTransient<IQueryHandler<GetStructureByIdQuery, StructureResponse>, GetStructureByIdQueryHandler>();
            services.AddTransient<IQueryHandler<GetStructureListQuery, StructureListResponse>, GetStructureListQueryHandler>();
            services.AddTransient<IQueryHandler<GetStructureUsersQuery, StructureUserResponse>, GetStructureUsersQueryHandler>();

            services.AddTransient<ICommandHandler<RegisterAppServiceCommand>, RegisterAppServiceCommandHandler>();
            services.AddTransient<ICommandHandler<EditAppServiceCommand>, EditAppServiceCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteAppServiceCommand>, DeleteAppServiceCommandHandler>();
            services.AddTransient<ICommandHandler<DisableAppServiceCommand>, DisableAppServiceCommandHandler>();
            services.AddTransient<ICommandHandler<EditAppServiceFeaturesCommand>, EditAppServiceFeaturesCommandHandler>();
            services.AddTransient<ICommandHandler<EditFeatureAppServiceCommand>, EditFeatureAppServiceCommandHandler>();
        }
    }
}
