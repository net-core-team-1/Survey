using Identity.Api.Contrats.Structures.Responses;
using Identity.Api.Extensions.AppServiceCommandQueryHandlers;
using Identity.Api.Extensions.FeatureCommandQueryHandlers;
using Identity.Api.Extensions.RoleCommandQueryHandlers;
using Identity.Api.Extensions.StructureCommandQueryHandlers;
using Identity.Api.Extensions.UserCommandQueryHandlers;
using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Events;
using Identity.Api.Identity.Domain.Structures.Events.RejectedEvents;
using Identity.Api.Identity.Domain.Structures.Queries;
using Identity.Api.Services.AppServices.CommandHandlers;
using Identity.Api.Services.Structures.Commands;
using Identity.Api.Services.Structures.QueryHandlers;
using Microsoft.Extensions.DependencyInjection;
using Survey.Common.CQRS.Events;
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
            services.RegisterStructureCommandQueryHandlers();
            services.RegisterAppServiceCommandQueryHandlers();
        }
    }
}
