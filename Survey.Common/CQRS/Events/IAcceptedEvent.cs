using Common.Types.Types.Events;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Common.CQRS.Events
{
    public interface IAcceptedEvent<T> : IEvent
        where T : ICommand
    {
        IEventKey Key { get; }
        IAcceptedEvent<T> CreateFrom(T command);
    }
}
