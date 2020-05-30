using Common.Types.Types.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Outbox
{
    public class OutboxMessage
    {
        public OutboxMessage(DateTime createdAt, IEvent @event)
        {
            CreatedAt = createdAt;
            Event = @event;
        }

        public long Id { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public IEvent Event { get; private set; }
    }
}
