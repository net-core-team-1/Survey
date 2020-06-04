using Common.Types.Types.Events;
using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Domain.Users.Events.EventKeys;
using Survey.Common.CQRS.Events;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Events
{
    public class UserUnregistredEvent : AcceptedEventBase<UnregisterUserCommand>
    {
        public Guid UserId { get; }
        public string Reason { get; }
        public Guid DeletedBy { get; }
        public DateTime DeletedAt { get; }

        public UserUnregistredEvent(Guid userId, string reason, Guid deletedBy, DateTime deletedAt)
            : this()
        {
            UserId = userId;
            Reason = reason;
            DeletedBy = deletedBy;
            DeletedAt = deletedAt;
        }

        public UserUnregistredEvent() : base() { }

    }
}
