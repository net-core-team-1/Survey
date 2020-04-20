using Common.Types.CQRS.ServiceBus.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey.Common.CQRS.ServiceBus.RabbitMQ
{
    public class RabbitMqConnectionFactory
    {
        public RabbitMqConnectionFactory()
        {
            
        }
        public static IModel Create(IServiceScopeFactory serviceScopeFactory)
        {
            var _options = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<RabbitMqOptions>();

            var connection = new ConnectionFactory
            {
                Port = _options.Port,
                VirtualHost = _options.VirtualHost,
                UserName = _options.Username,
                Password = _options.Password,
                RequestedConnectionTimeout = _options.RequestedConnectionTimeout,
                DispatchConsumersAsync = true

            }.CreateConnection(_options.HostNames.ToList(), _options.ConnectionName);

            return connection.CreateModel();
        }

    
    }
}
