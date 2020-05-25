using Common.CQRS.ServiceBus.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Survey.CQRS.ServiceBus.RabbitMQ;
using System.Linq;


namespace Survey.CQRS.ServiceBus
{
    public static class Extensions
    {
        public static IServiceCollection ConfigureServiceBus(this IServiceCollection services, IConfiguration configuration)
        {

            var options = new RabbitMqOptions();
            configuration.GetSection("rabbitMq").Bind(options);

            services.AddSingleton(options);


            var connection = new ConnectionFactory
            {

                Port = options.Port,
                VirtualHost = options.VirtualHost,
                UserName = options.Username,
                Password = options.Password,
                RequestedConnectionTimeout =new System.TimeSpan(0,0, options.RequestedConnectionTimeout),
                DispatchConsumersAsync = true

            }.CreateConnection(options.HostNames.ToList(), options.ConnectionName);

            services.AddSingleton(connection);

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
