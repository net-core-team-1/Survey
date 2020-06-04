using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structures.Events
{
    public class StructureUsersEditedEvent : AcceptedEventBase<EditStructureUsersCommand>
    {
        public Guid StructureId { get; }
        public Guid AssignedBy { get; }
        public List<Guid> Users { get; }

        public StructureUsersEditedEvent() : base()
        {
        }
        public StructureUsersEditedEvent(Guid structureId, Guid assignedBy, List<Guid> users)
            : this()
        {
            StructureId = structureId;
            AssignedBy = assignedBy;
            Users = users;
        }

    }
}
