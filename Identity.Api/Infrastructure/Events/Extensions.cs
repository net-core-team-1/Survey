using Identity.Api.Infrastructure.Data.EventMappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Infrastructure.Events
{
    public static class Extensions
    {
        public static void AddEventMapper(this IServiceCollection services)
        {
            services.AddSingleton<IEventMapper, EventMapper>();
        }
    }
}
