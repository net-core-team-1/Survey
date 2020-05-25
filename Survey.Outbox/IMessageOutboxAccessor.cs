using Survey.Outbox.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Outbox
{
    public interface IMessageOutboxAccessor
    {
        Task<IReadOnlyList<OutboxMessage>> GetUnsentAsync();
        Task ProcessAsync(OutboxMessage message);
        Task ProcessAsync(IEnumerable<OutboxMessage> outboxMessages);
    }
}
