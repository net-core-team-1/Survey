using Common.Types.Types.ServiceBus.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Common.CQRS.ServiceBus.RabbitMQ
{
    public interface IConventionsProvider
    {
        IConventions Get<T>();
        IConventions Get(Type type);
    }
}
