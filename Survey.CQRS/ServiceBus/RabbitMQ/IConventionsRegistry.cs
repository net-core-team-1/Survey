﻿using Survey.CQRS.ServiceBus.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.CQRS.ServiceBus.RabbitMQ
{
    public interface IConventionsRegistry
    {
        void Add<T>(IConventions conventions);
        void Add(Type type, IConventions conventions);
        IConventions Get<T>();
        IConventions Get(Type type);
        IEnumerable<IConventions> GetAll();
    }
}
