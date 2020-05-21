using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;


namespace Identity.Api.Identity.Domain.Structures.Events.RejectedEvents
{
    public class StructureUsersRegistrationRejectedEvent : RejectedEventBase<RegisterStructureUserCommand>
    {
        public StructureUsersRegistrationRejectedEvent() : base()
        {
        }
        private StructureUsersRegistrationRejectedEvent(string reason, string code, RegisterStructureUserCommand command)
          : base(new StructureIdUserIdEventKey(command.StructureId, command.UserId), reason, code, command)
        {
        }
        public override IRejectedEvent<RegisterStructureUserCommand> CreateFrom(string reason, string code, RegisterStructureUserCommand command)
        {
            return new StructureUsersRegistrationRejectedEvent(reason, code, command);
        }
    }
}
