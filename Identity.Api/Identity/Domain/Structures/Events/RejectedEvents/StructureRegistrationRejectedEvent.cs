using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;


namespace Identity.Api.Identity.Domain.Structures.Events.RejectedEvents
{
    public class StructureRegistrationRejectedEvent : RejectedEventBase<RegisterStructureCommand>
    {
        public StructureRegistrationRejectedEvent() : base()
        {
        }
        private StructureRegistrationRejectedEvent(string reason, string code, RegisterStructureCommand command)
           : base(new StructureNameEventKey(command.Name), reason, code, command)
        {
        }
        public override IRejectedEvent<RegisterStructureCommand> CreateFrom(string reason, string code, RegisterStructureCommand command)
        {
            return new StructureRegistrationRejectedEvent(reason, code, command);
        }
    }
}
