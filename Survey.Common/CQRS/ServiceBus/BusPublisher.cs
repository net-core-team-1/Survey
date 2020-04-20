using Common.Types.Types.Events;
using Common.Types.Types.ServiceBus.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Survey.Common.CQRS.ServiceBus.RabbitMQ;
using Survey.Common.Types;
using System.Text;

namespace Common.Types.Types.ServiceBus
{
    public class BusPublisher : IBusPublisher
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConventionsProvider _conventionsProvider;
        private IConventions _conventions;



        public BusPublisher(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _conventionsProvider = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<IConventionsProvider>();
        }

        public void SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {  
            var _channel = RabbitMqConnectionFactory.Create(_serviceScopeFactory);
            _conventions = _conventionsProvider.Get(command.GetType());
            var message = JsonConvert.SerializeObject(command);
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(_conventions.Exchange, _conventions.RoutingKey, null, body);
           
        }

        public void PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var _channel = RabbitMqConnectionFactory.Create(_serviceScopeFactory);
            _conventions = _conventionsProvider.Get(@event.GetType());
            var message = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(_conventions.Exchange, _conventions.RoutingKey, null, body);
        }

    }
}
