using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;


namespace Identity.Api.Identity.Domain.Structures.Events.RejectedEvents
{
    public class StructureUsersEditionRejectedEvent : RejectedEventBase<EditStructureUsersCommand>
    {
        public StructureUsersEditionRejectedEvent() : base()
        {
        }
        private StructureUsersEditionRejectedEvent(string reason, string code, EditStructureUsersCommand command)
          : base(new StructureIdEventKey(command.StructureId), reason, code, command)
        {
        }
        public override IRejectedEvent<EditStructureUsersCommand> CreateFrom(string reason, string code, EditStructureUsersCommand command)
        {
            return new StructureUsersEditionRejectedEvent(reason, code, command);
        }
    }
}
