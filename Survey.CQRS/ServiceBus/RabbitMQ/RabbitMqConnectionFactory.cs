using Common.CQRS.ServiceBus.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey.CQRS.ServiceBus.RabbitMQ
{
    public class RabbitMqConnectionFactory:IDisposable
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
                RequestedConnectionTimeout =new TimeSpan(0,0,options.RequestedConnectionTimeout),
                DispatchConsumersAsync = true

            }.CreateConnection(options.HostNames.ToList(), options.ConnectionName);


            return connection.CreateModel();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
