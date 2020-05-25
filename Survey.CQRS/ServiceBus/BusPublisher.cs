using Survey.CQRS.ServiceBus.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Text;
using Survey.CQRS.Commands;
using Survey.CQRS.Events;
using Newtonsoft.Json;

namespace Survey.CQRS.ServiceBus
{
    public class BusPublisher : IBusPublisher
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly IConventionsProvider _conventionsProvider;
        private IConventions _conventions;
        private IModel _channel;

        public BusPublisher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _channel = RabbitMqConnectionFactory.Create(_serviceProvider);
            _conventionsProvider = _serviceProvider.GetRequiredService<IConventionsProvider>();
        }

        public void SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            _conventions = _conventionsProvider.Get(command.GetType());
            var message = JsonConvert.SerializeObject(command);
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(_conventions.Exchange, _conventions.RoutingKey, null, body);
            

        }

        public void PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            _conventions = _conventionsProvider.Get(@event.GetType());
            var message = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(_conventions.Exchange, _conventions.RoutingKey, null, body);
           
        }

    }
}
