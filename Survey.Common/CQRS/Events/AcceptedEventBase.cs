using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Common.CQRS.Events
{
    public abstract class AcceptedEventBase<T> : IAcceptedEvent<T>
        where T : ICommand
    {
        public IEventKey Key { get; }
        protected AcceptedEventBase() { }
        protected AcceptedEventBase(IEventKey key)
        {
            Key = key;
        }

        public abstract IAcceptedEvent<T> CreateFrom(T command);
    }
}
