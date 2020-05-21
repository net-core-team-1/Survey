using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;


namespace Identity.Api.Identity.Domain.Structures.Events.RejectedEvents
{
    public class StructureEditionRejectedEvent : RejectedEventBase<EditStructureCommand>
    {
        public StructureEditionRejectedEvent() : base()
        {
        }
        private StructureEditionRejectedEvent(string reason, string code, EditStructureCommand command)
            :base(new StructureIdEventKey(command.StructureId), reason, code, command)
        {
        }
        public override IRejectedEvent<EditStructureCommand> CreateFrom(string reason, string code, EditStructureCommand command)
        {
            return new StructureEditionRejectedEvent(reason, code, command);
        }
    }
}
