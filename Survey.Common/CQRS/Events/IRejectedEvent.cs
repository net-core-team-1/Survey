using Common.Types.Types.Events;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Common.CQRS.Events
{
    public interface IRejectedEvent<T> : IEvent
        where T : ICommand
    {
        string Reason { get; }
        string Code { get; }

        IRejectedEvent<T> CreateFrom(T command, string reason, string code);
    }
}
