using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Survey.Transverse.Infrastracture.Data;


namespace Survey.Transverse.API._Configuration
{
    public static class ConnectionProvider
    {
        public static readonly LoggerFactory MyLoggerFactory
                    = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContextPool<TransverseContext>(options =>
            {

                options.UseSqlServer(configuration.GetConnectionString("TransverseConnectionString"))
                       .UseLazyLoadingProxies()
                       .UseLoggerFactory(MyLoggerFactory)
                       .EnableSensitiveDataLogging();

            });
            return services;
        }
    }
}
