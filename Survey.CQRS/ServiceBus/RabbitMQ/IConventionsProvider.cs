using Survey.CQRS.ServiceBus.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.CQRS.ServiceBus.RabbitMQ
{
    public interface IConventionsProvider
    {
        IConventions Get<T>();
        IConventions Get(Type type);
    }
}
