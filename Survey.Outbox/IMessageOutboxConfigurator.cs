using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Outbox
{
    public interface IMessageOutboxConfigurator
    {
        OutboxOptions Options { get; }
    }
}
