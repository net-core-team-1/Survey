using Common.Types.CQRS.ServiceBus.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey.Common.CQRS.ServiceBus.RabbitMQ
{
    public class RabbitMqConnectionFactory : IDisposable
    {

        public static IModel Create(IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<RabbitMqOptions>();

            var connection = new ConnectionFactory
            {
                Port = options.Port,
                VirtualHost = options.VirtualHost,
                UserName = options.Username,
                Password = options.Password,
                RequestedConnectionTimeout = options.RequestedConnectionTimeout,
                DispatchConsumersAsync = true

            }.CreateConnection(options.HostNames.ToList(), options.ConnectionName);


            return connection.CreateModel();
        }

        public static IConnection CreateConnection(IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<RabbitMqOptions>();

            var connection = new ConnectionFactory
            {
                Port = options.Port,
                VirtualHost = options.VirtualHost,
                UserName = options.Username,
                Password = options.Password,
                RequestedConnectionTimeout = options.RequestedConnectionTimeout,
                DispatchConsumersAsync = true

            }.CreateConnection(options.HostNames.ToList(), options.ConnectionName);

            return connection;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
