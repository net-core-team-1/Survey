using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Domain.Roles.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Events
{
    public class RoleUnregistredEvent : AcceptedEventBase<UnregisterRoleCommand>
    {
        public Guid Id { get; }
        public Guid DeletedBy { get; }
        public DateTime DeleteOn { get; }
        public string Reason { get; }
        public RoleUnregistredEvent() : base()
        {
        }

        public RoleUnregistredEvent(Guid id, Guid deletedBy, DateTime deleteOn, string reason)
            : this()
        {
            Id = id;
            DeletedBy = deletedBy;
            DeleteOn = deleteOn;
            Reason = reason;
        }

    }
}
