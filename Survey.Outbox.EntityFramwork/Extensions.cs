using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Outbox.EntityFramwork
{
    public static class Extensions
    {
        public static void RegisterEntityFrameworkOutbox<T>(this IServiceCollection services)
            where T : DbContext
        {
            
            services.AddDbContext<T>();

            services.AddTransient<IMessageOutbox, EntityFrameworkMessageOutbox<T>>();
            services.AddTransient<IMessageOutboxAccessor, EntityFrameworkMessageOutbox<T>>();
        }
    }
}
