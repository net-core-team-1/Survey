﻿using Common.Types.Types.ServiceBus.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Common.CQRS.ServiceBus.RabbitMQ
{
    public class MessageConventions : IConventions
    {
        public Type Type { get; }
        public string RoutingKey { get; }
        public string Exchange { get; }
        public string Queue { get; }

        public MessageConventions(Type type, string routingKey, string exchange, string queue)
        {
            Type = type;
            RoutingKey = routingKey;
            Exchange = exchange;
            Queue = queue;
        }
    }
}
