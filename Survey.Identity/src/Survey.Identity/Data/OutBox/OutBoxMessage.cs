using Survey.CQRS.Events;
using Survey.Identity.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Data.OutBox
{
    public class OutboxMessage
    {
        public OutboxMessage(DateTime createdAt, IEvent @event)
        {
            CreatedAt = createdAt;
            Event = @event;
        }

        public Guid Id { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public virtual IEvent Event { get; private set; }
        public DateTime? ProcessedAt { get; private set; }
        protected OutboxMessage()
        {

        }
        public void Process()
        {
            ProcessedAt = DateTime.UtcNow;
        }
    }
}
