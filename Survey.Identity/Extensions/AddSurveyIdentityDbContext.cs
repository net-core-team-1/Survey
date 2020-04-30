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
            services.AddDbContextPool<SurveyIdentityContext>(options =>
            {

                options.UseSqlServer(configuration.GetConnectionString("IdentityConnectionString"))
                       .UseLazyLoadingProxies();



            });
            return services;
        }
    }
}
