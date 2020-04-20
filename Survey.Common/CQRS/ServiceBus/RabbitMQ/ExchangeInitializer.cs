using Common.Types.CQRS.ServiceBus.RabbitMQ;
using RabbitMQ.Client;
using Survey.Common.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Common.CQRS.ServiceBus.RabbitMQ
{
    public class ExchangeInitializer : IExchangeInitializer
    {
        private const string DefaultType = "topic";
        private readonly IConnection _connection;
        private readonly RabbitMqOptions _options;

        public ExchangeInitializer(IConnection connection, RabbitMqOptions options)
        {
            _connection = connection;
            _options = options;
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

            using (var channel = _connection.CreateModel())
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
