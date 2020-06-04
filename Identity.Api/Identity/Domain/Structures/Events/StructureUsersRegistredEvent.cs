using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structures.Events
{
    public class StructureUsersRegistredEvent : AcceptedEventBase<RegisterStructureUserCommand>
    {
        public Guid StructureId { get; }
        public Guid UserId { get; }

        public StructureUsersRegistredEvent() : base()
        {
        }

        public StructureUsersRegistredEvent(Guid structureId, Guid userId)
            : this()
        {
            StructureId = structureId;
            UserId = userId;
        }
    }
}
