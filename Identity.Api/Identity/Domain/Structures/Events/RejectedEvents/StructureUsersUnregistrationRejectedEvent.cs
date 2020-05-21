using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;


namespace Identity.Api.Identity.Domain.Structures.Events.RejectedEvents
{
    public class StructureUsersUnregistrationRejectedEvent : RejectedEventBase<UnregisterStructureUserCommand>
    {
        public StructureUsersUnregistrationRejectedEvent() : base()
        {
        }
        private StructureUsersUnregistrationRejectedEvent(string reason, string code, UnregisterStructureUserCommand command)
         : base(new StructureIdUserIdEventKey(command.StructureId, command.UserId), reason, code, command)
        {
        }
        public override IRejectedEvent<UnregisterStructureUserCommand> CreateFrom(string reason, string code, UnregisterStructureUserCommand command)
        {
            return new StructureUsersUnregistrationRejectedEvent(reason, code, command);
        }
    }
}
