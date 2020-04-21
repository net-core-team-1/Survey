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
        private IModel _channel;
        private readonly IConventionsProvider _conventionsProvider;
        private readonly RabbitMqOptions _options;
        private readonly QosOptions _qosOptions;
        private readonly IServiceProvider _serviceProvider;


        public BusSubscriber(IServiceScopeFactory serviceScopeFactory)
        {

            _serviceScopeFactory = serviceScopeFactory;
            _serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
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
            _channel = _serviceProvider.GetRequiredService<IConnection>().CreateModel();

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
                    var scope = _serviceScopeFactory.CreateScope();
                    var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

                    if (handler != null)
                    {
                        var payload = Encoding.UTF8.GetString(args.Body);
                        var message = JsonConvert.DeserializeObject(payload, typeof(TCommand));
                        var conreteType = typeof(ICommandHandler<>).MakeGenericType(typeof(TCommand));
                        await (Task<Result>)conreteType.GetMethod("Handle").Invoke(handler, new object[] { message });
                        _channel.BasicAck(args.DeliveryTag, false);
                    }
                }
                catch (Exception ex)
                {
                    _channel.BasicAck(args.DeliveryTag, false);
                    throw;
                }
            };
            _channel.BasicConsume(conventions.Queue, true, consumer);
        }

        public void SubscribeEvent<TEvent>()
            where TEvent : IEvent
        {
            _channel = _serviceProvider.GetRequiredService<IConnection>().CreateModel();
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

                    var handlers = _serviceProvider.GetServices<IEventHandler<TEvent>>();
                    foreach (IEventHandler<TEvent> handler in handlers)
                    {
                        if (handler == null) continue;

                        var payload = Encoding.UTF8.GetString(args.Body);
                        var @event = JsonConvert.DeserializeObject(payload, typeof(TEvent));
                        var conreteType = typeof(IEventHandler<>).MakeGenericType(typeof(TEvent));
                        await (Task<Result>)conreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });
                    }
                    if (handlers != null)
                        _channel.BasicAck(args.DeliveryTag, false);


                }
                catch (Exception ex)
                {
                    _channel.BasicAck(args.DeliveryTag, false);
                    throw;
                }
            };

            _channel.BasicConsume(conventions.Queue, false, consumer);
        }

    }
}
