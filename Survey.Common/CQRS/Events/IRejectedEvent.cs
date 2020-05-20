﻿using Common.Types.Types.Events;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Common.CQRS.Events
{
    public interface IRejectedEvent<T> : IEvent
        where T : ICommand
    {
        IEventKey Key { get; }
        string Reason { get; }
        string Code { get; }
        T Command { get; }
        IRejectedEvent<T> CreateFrom(string reason, string code, T command);
    }
}
