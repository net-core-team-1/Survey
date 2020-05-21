using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;


namespace Identity.Api.Identity.Domain.Structures.Events.RejectedEvents
{
    public class StructureDisablingRejectedEvent : RejectedEventBase<DisableStructureCommand>
    {
        public StructureDisablingRejectedEvent() : base()
        {
        }
        private StructureDisablingRejectedEvent(string reason, string code, DisableStructureCommand command)
         : base(new StructureIdEventKey(command.StructureId), reason, code, command)
        {
        }
        public override IRejectedEvent<DisableStructureCommand> CreateFrom(string reason, string code, DisableStructureCommand command)
        {
            return new StructureDisablingRejectedEvent(reason, code, command);
        }
    }
}
