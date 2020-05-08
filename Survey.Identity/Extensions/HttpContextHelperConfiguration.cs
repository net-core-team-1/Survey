using Microsoft.Extensions.DependencyInjection;
using Survey.Identity.Util;

namespace Survey.Idendity.Extensions
{
    public static class HttpContextHelperConfiguration
    {
        public static IServiceCollection AddHttpContextHelper(this IServiceCollection services)
        {
            services.AddTransient<HttpContextHelper, HttpContextHelper>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
