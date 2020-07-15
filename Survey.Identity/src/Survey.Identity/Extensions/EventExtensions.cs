using Survey.Identity.Data.OutBox;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EventExtensions
    {
        public static IServiceCollection AddEvents(this IServiceCollection services)
        {

            //services.AddSingleton<OutBoxPublisher>();
            //services.AddHostedService<OutBoxPublisherBackgroundService>();

            return services;
        }
    }
}
