using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structures.Events
{
    public class StructureDeletedEvent : AcceptedEventBase<DeleteStructureCommand>
    {
        public Guid StructureId { get; }
        public string Reason { get; }
        public Guid DeletedBy { get; }
        public StructureDeletedEvent() : base()
        {
        }

        public StructureDeletedEvent(Guid structureId, string reason, Guid deletedBy)
            : this()
        {
            StructureId = structureId;
            Reason = reason;
            DeletedBy = deletedBy;
        }

    }
}
