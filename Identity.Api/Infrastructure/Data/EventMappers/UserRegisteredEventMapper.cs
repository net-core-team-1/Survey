using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.Outbox;
using Identity.Api.Infrastructure.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Infrastructure.Data.EventMappers
{
    public class EventMapper : IEventMapper
    {
        public IEnumerable<OutboxMessage> Map(IDomainEntity entity, DateTime occurredAt)
        {
            return entity.Events.Select(entry =>
                                    new OutboxMessage(DateTime.Now, entry));
        }
    }
}
