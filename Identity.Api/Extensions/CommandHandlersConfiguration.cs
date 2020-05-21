using Identity.Api.Contrats.Structures.Responses;
using Identity.Api.Extensions.FeatureCommandQueryHandlers;
using Identity.Api.Extensions.RoleCommandQueryHandlers;
using Identity.Api.Extensions.UserCommandQueryHandlers;
using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Queries;
using Identity.Api.Services.AppServices.CommandHandlers;
using Identity.Api.Services.Structures.Commands;
using Identity.Api.Services.Structures.QueryHandlers;
using Microsoft.Extensions.DependencyInjection;
using Survey.Common.Types;

namespace Identity.Api.Extensions.CommandHandlersRegistration
{
    public static class CommandHandlersConfiguration
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            services.RegisterUserCommandQueryHandlers();
            services.RegisterRoleCommandQueryHandlers();
            services.RegisterFeatureCommandQueryHandlers();


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

        }
    }
}
