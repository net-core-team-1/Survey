using Common.CQRS.ServiceBus.RabbitMQ;
using RabbitMQ.Client;
using Survey.CQRS.Messages;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Survey.CQRS.ServiceBus.RabbitMQ
{
    public class ExchangeInitializer : IExchangeInitializer
    {
        private const string DefaultType = "topic";
        //private readonly IConnection _connection;
        private readonly RabbitMqOptions _options;
        private readonly IServiceProvider _serviceProvider;

        public ExchangeInitializer(RabbitMqOptions options,IServiceProvider serviceProvider)
        {
            //_connection = connection;
            _options = options;
            _serviceProvider = serviceProvider;
        }

        public Task Initialize()
        {
            var exchanges = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsDefined(typeof(MessageAttribute), false))
                .Select(t => t.GetCustomAttribute<MessageAttribute>().Exchange)
                .Distinct()
                .ToList();

            using (var channel = RabbitMqConnectionFactory.Create(_serviceProvider))
            {
                if (_options.Exchange?.Declare == true)
                {
                    channel.ExchangeDeclare(_options.Exchange.Name, _options.Exchange.Type, _options.Exchange.Durable,
                        _options.Exchange.AutoDelete);
                }

                foreach (var exchange in exchanges)
                {
                    if (exchange.Equals(_options.Exchange?.Name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        continue;
                    }

                    channel.ExchangeDeclare(exchange, DefaultType, true);
                    
                }

                channel.Close();
            }

            return Task.CompletedTask;
        }



    }
}
