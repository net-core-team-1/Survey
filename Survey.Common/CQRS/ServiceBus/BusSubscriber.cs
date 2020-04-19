using Common.Types.CQRS.ServiceBus.RabbitMQ;
using Common.Types.Types.Events;
using Common.Types.Types.ServiceBus.RabbitMQ;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Survey.Common.CQRS.ServiceBus.RabbitMQ;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Types.CQRS.ServiceBus.RabbitMQ.RabbitMqOptions;

namespace Common.Types.Types.ServiceBus
{
    public class BusSubscriber : IBusSubscriber
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly Dictionary<string, List<Type>> _handlers;
        private readonly List<Type> _eventTypes;
        private readonly IModel _channel;
        private readonly IConventionsProvider _conventionsProvider;
        private readonly RabbitMqOptions _options;
        private readonly QosOptions _qosOptions;
        private readonly IServiceProvider _serviceProvider;


        public BusSubscriber(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
            _serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
            _channel = _serviceProvider.GetRequiredService<IConnection>().CreateModel();
            _conventionsProvider = _serviceProvider.GetRequiredService<IConventionsProvider>();
            _options = _serviceProvider.GetService<RabbitMqOptions>();
            _qosOptions = _options?.Qos ?? new RabbitMqOptions.QosOptions();
            if (_qosOptions.PrefetchCount < 1)
            {
                _qosOptions.PrefetchCount = 1;
            }

        }

        public void SubscribeCommand<TCommand>()
            where TCommand : ICommand
        {

            var conventions = _conventionsProvider.Get<TCommand>();
            var declare = _options.Queue?.Declare ?? true;
            var durable = _options.Queue?.Durable ?? true;
            var exclusive = _options.Queue?.Exclusive ?? false;
            var autoDelete = _options.Queue?.AutoDelete ?? false;

            if (declare)
            {
                _channel.QueueDeclare(conventions.Queue, durable, exclusive, autoDelete);
            }

            _channel.QueueBind(conventions.Queue, conventions.Exchange, conventions.RoutingKey);
            _channel.BasicQos(_qosOptions.PrefetchSize, _qosOptions.PrefetchCount, _qosOptions.Global);

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.Received += async (model, args) =>
            {
                try
                {
                    var test = _serviceProvider.GetServices<ICommandHandler<TCommand>>();
                    var handler = _serviceProvider.GetService<ICommandHandler<TCommand>>();
                    
                    if (handler != null)
                    {
                        var payload = Encoding.UTF8.GetString(args.Body);
                        var message = JsonConvert.DeserializeObject(payload, typeof(TCommand));
                        var conreteType = typeof(ICommandHandler<>).MakeGenericType(typeof(TCommand));
                        await (Task<Result>)conreteType.GetMethod("Handle").Invoke(handler, new object[] { message });

                    }

                }
                catch (Exception ex)
                {
                    _channel.BasicNack(args.DeliveryTag, false, true);
                    throw;
                }
            };
            _channel.BasicConsume(conventions.Queue, false, consumer);
        }

        public void SubscribeEvent<TEvent, THandler>()
            where TEvent : IEvent
            where THandler : IEventHandler<TEvent>
        {

            var eventName = typeof(TEvent).Name;
            var handlerType = typeof(THandler);

            if (!_eventTypes.Contains(typeof(TEvent)))
            {
                _eventTypes.Add(typeof(TEvent));
            }

            if (!_handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, new List<Type>());
            }

            if (_handlers[eventName].Any(s => s.GetType() == handlerType))
            {
                throw new ArgumentException(
                    $"Handler Type {eventName} already is registered for '{eventName}'", nameof(handlerType));
            }

            _handlers[eventName].Add(handlerType);

            var conventions = _conventionsProvider.Get<TEvent>();
            var declare = _options.Queue?.Declare ?? true;
            var durable = _options.Queue?.Durable ?? true;
            var exclusive = _options.Queue?.Exclusive ?? false;
            var autoDelete = _options.Queue?.AutoDelete ?? false;

            if (declare)
            {
                _channel.QueueDeclare(conventions.Queue, durable, exclusive, autoDelete);
            }

            _channel.QueueBind(conventions.Queue, conventions.Exchange, conventions.RoutingKey);
            _channel.BasicQos(_qosOptions.PrefetchSize, _qosOptions.PrefetchCount, _qosOptions.Global);

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.Received += async (model, args) =>
            {
                var scope = _serviceScopeFactory.CreateScope();
                try
                {
                    var subscriptions = _handlers[eventName];
                    foreach (var subscription in subscriptions)
                    {
                        var handler = _serviceProvider.GetService<THandler>();
                        if (handler == null) continue;

                        var payload = Encoding.UTF8.GetString(args.Body);
                        var eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);
                        var @event = JsonConvert.DeserializeObject(payload, eventType);
                        var conreteType = typeof(IEventHandler<>).MakeGenericType(eventType);
                        await (Task<Result>)conreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });
                    }

                }
                catch (Exception ex)
                {
                    _channel.BasicNack(args.DeliveryTag, false, true);
                    throw;
                }
            };

            _channel.BasicConsume(conventions.Queue, false, consumer);
        }

    }
}
