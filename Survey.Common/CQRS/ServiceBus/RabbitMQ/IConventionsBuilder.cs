﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Common.CQRS.ServiceBus.RabbitMQ
{
    public interface IConventionsBuilder
    {
        string GetRoutingKey(Type type);
        string GetExchange(Type type);
        string GetQueue(Type type);
    }
}
