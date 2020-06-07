using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Survey.Identity.Data;

namespace Survey.Identity.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddSurveyIdentityDbContext(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddEntityFrameworkSqlServer()
                    .AddEntityFrameworkProxies();


            services.AddDbContextPool<SurveyIdentityContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("IdentityConnectionString"))
                      .UseLazyLoadingProxies();
                optionsBuilder.UseInternalServiceProvider(serviceProvider);

            });
            return services;
        }
    }
}
