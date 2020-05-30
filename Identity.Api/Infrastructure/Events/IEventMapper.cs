using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.Outbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Infrastructure.Events
{
    public interface IEventMapper
    {
        IEnumerable<OutboxMessage> Map(IDomainEntity entity, DateTime occurredAt);
    }
}
