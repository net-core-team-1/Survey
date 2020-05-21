using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;


namespace Identity.Api.Identity.Domain.Structures.Events.RejectedEvents
{
    public class StructureDeletingRejectedEvent : RejectedEventBase<DeleteStructureCommand>
    {
        public StructureDeletingRejectedEvent() : base()
        {
        }
        private StructureDeletingRejectedEvent(string reason, string code, DeleteStructureCommand command)
         : base(new StructureIdEventKey(command.StructureId), reason, code, command)
        {
        }
        public override IRejectedEvent<DeleteStructureCommand> CreateFrom(string reason, string code, DeleteStructureCommand command)
        {
            return new StructureDeletingRejectedEvent(reason, code, command);
        }
    }
}
