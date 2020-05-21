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

        private StructureDeletedEvent(Guid structureId, string reason, Guid deletedBy)
            : base(new StructureIdEventKey(structureId))
        {
            StructureId = structureId;
            Reason = reason;
            DeletedBy = deletedBy;
        }

        public override IAcceptedEvent<DeleteStructureCommand> CreateFrom(DeleteStructureCommand command)
        {
            return new StructureDeletedEvent(command.StructureId, command.Reason, command.DeletedBy);
        }
    }
}
