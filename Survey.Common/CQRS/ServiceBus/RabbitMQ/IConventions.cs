using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Types.Types.ServiceBus.RabbitMQ
{
    public interface IConventions
    {
        Type Type { get; }
        string RoutingKey { get; }
        string Exchange { get; }
        string Queue { get; }
    }
}
