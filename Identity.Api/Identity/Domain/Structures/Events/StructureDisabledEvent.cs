using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structures.Events
{
    public class StructureDisabledEvent : AcceptedEventBase<DisableStructureCommand>
    {
        public Guid StructureId { get; }
        public string Reason { get; }
        public Guid DisabledBy { get; }

        public StructureDisabledEvent() : base()
        {
        }
        private StructureDisabledEvent(Guid structureId, string reason, Guid disabledBy)
            : base(new StructureIdEventKey(structureId))
        {
            StructureId = structureId;
            Reason = reason;
            DisabledBy = disabledBy;
        }

        public override IAcceptedEvent<DisableStructureCommand> CreateFrom(DisableStructureCommand command)
        {
            return new StructureDisabledEvent(command.StructureId, command.Reason, command.DisabledBy);
        }
    }
}
