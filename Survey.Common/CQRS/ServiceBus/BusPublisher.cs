using Common.Types.Types.Events;
using Common.Types.Types.ServiceBus.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Survey.Common.CQRS.ServiceBus.RabbitMQ;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Types.Types.ServiceBus
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
            //var channel = RabbitMqConnectionFactory.Create(_serviceProvider);
            //if(_channel.IsClosed)
            //    _channel = _serviceProvider.GetRequiredService<IConnection>().CreateModel();
            _conventions = _conventionsProvider.Get(command.GetType());
            var message = JsonConvert.SerializeObject(command);
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(_conventions.Exchange, _conventions.RoutingKey, null, body);


        }
        public Task PublishAsync<T>(T @event, string messageId = null, string correlationId = null,
           string spanContext = null, object messageContext = null, IDictionary<string, object> headers = null)
           where T : class
        {
            _conventions = _conventionsProvider.Get(@event.GetType());
            var message = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(message);
            var properties = _channel.CreateBasicProperties();
            properties.MessageId = string.IsNullOrWhiteSpace(messageId)
                ? Guid.NewGuid().ToString("N")
                : messageId;
            properties.CorrelationId = string.IsNullOrWhiteSpace(correlationId)
                ? Guid.NewGuid().ToString("N")
                : correlationId;
            properties.Timestamp = new AmqpTimestamp(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            properties.Headers = new Dictionary<string, object>();

            //if (_contextEnabled)
            //{
            //    IncludeMessageContext(messageContext, properties);
            //}

            //if (!string.IsNullOrWhiteSpace(spanContext))
            //{
            //    properties.Headers.Add(_spanContextHeader, spanContext);
            //}

            if (headers != null)
            {
                foreach (var (key, value) in headers)
                {
                    if (string.IsNullOrWhiteSpace(key) || value is null)
                    {
                        continue;
                    }

                    properties.Headers.TryAdd(key, value);
                }
            }

            _channel.BasicPublish(_conventions.Exchange, _conventions.RoutingKey, null, body);

            return Task.CompletedTask;
        }
        //private void IncludeMessageContext(object context, IBasicProperties properties)
        //{
        //    if (context is {})
        //    {
        //        properties.Headers.Add(_contextProvider.HeaderName, _serializer.Serialize(context));
        //        return;
        //    }

        //    properties.Headers.Add(_contextProvider.HeaderName, EmptyContext);
        //}
        //public void PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
        //{
        //    //var channel = RabbitMqConnectionFactory.Create(_serviceProvider);
        //    //if (_channel.IsClosed)
        //    //    _channel = _serviceProvider.GetRequiredService<IConnection>().CreateModel();
        //    _conventions = _conventionsProvider.Get(@event.GetType());
        //    var message = JsonConvert.SerializeObject(@event);
        //    var body = Encoding.UTF8.GetBytes(message);
        //    _channel.BasicPublish(_conventions.Exchange, _conventions.RoutingKey, null, body);

        //}

    }
}
