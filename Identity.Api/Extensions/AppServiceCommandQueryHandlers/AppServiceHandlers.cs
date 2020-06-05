using Identity.Api.Contrats.AppServices.Responses;
using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Identity.Domain.AppServices.Queries;
using Identity.Api.Services.AppServices.CommandHandlers;
using Identity.Api.Services.AppServices.QueryHandlers;
using Microsoft.Extensions.DependencyInjection;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Extensions.AppServiceCommandQueryHandlers
{
    public static class AppServiceHandlers
    {
        public static void RegisterAppServiceCommandQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<RegisterAppServiceCommand>, RegisterAppServiceCommandHandler>();
            services.AddTransient<ICommandHandler<EditAppServiceCommand>, EditAppServiceCommandHandler>();
            services.AddTransient<ICommandHandler<DeleteAppServiceCommand>, DeleteAppServiceCommandHandler>();
            services.AddTransient<ICommandHandler<DisableAppServiceCommand>, DisableAppServiceCommandHandler>();
            services.AddTransient<ICommandHandler<EditAppServiceFeaturesCommand>, EditAppServiceFeaturesCommandHandler>();

            services.AddTransient<IQueryHandler<GetAppServiceByIdQuery, AppServiceResponse>, GetAppServiceByIdQueryHandler>();
            services.AddTransient<IQueryHandler<GetListAppServiceQuery, AppServiceListResponse>, GetListAppServiceQueryHandler>();
            services.AddTransient<IQueryHandler<GetDetailledAppServiceQuery, AppServiceDetailledResponse>, GetDetailledAppServiceQueryHandler>();
        }
    }
}
