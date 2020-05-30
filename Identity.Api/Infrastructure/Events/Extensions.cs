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
        public static void AddEvents(this IServiceCollection services)
        {
            List<IEventMapper> eventMappers = new List<IEventMapper>();
            eventMappers.Add(new UserRegisteredEventMapper());
            services.AddSingleton(eventMappers);
        }
    }
}
