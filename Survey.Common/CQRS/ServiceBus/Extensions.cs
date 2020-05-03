using Common.Types.CQRS.ServiceBus.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Survey.Common.CQRS.ServiceBus.RabbitMQ;
using System.Linq;

namespace Common.Types.Types.ServiceBus
{
    public static class Extensions
    {
        public static IServiceCollection ConfigureServiceBus(this IServiceCollection services, IConfiguration configuration)
        {

            var options = new RabbitMqOptions();
            configuration.GetSection("rabbitMq").Bind(options);

            services.AddSingleton(options);

            services.AddSingleton<IConventionsBuilder, ConventionsBuilder>();
            services.AddSingleton<IConventionsProvider, ConventionsProvider>();
            services.AddSingleton<IConventionsRegistry, ConventionsRegistry>();
            services.AddSingleton<ExchangeInitializer>();

            services.AddSingleton<IBusPublisher, BusPublisher>();
            services.AddSingleton<IBusSubscriber, BusSubscriber>();

            return services;
        }
    }
}
