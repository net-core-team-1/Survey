using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Outbox.Configurator
{
    public class MessageOutboxConfigurator : IMessageOutboxConfigurator
    {
        public OutboxOptions Options { get; }

        public MessageOutboxConfigurator(OutboxOptions options)
        {

            Options = options;
        }
    }
}
