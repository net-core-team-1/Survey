using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Events.EventKeys;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structures.Events
{
    public class StructureUsersUnregistredEvent : AcceptedEventBase<UnregisterStructureUserCommand>
    {
        public Guid StructureId { get; }
        public Guid UserId { get; }
        public StructureUsersUnregistredEvent() : base()
        {
        }

        public StructureUsersUnregistredEvent(Guid structureId, Guid userId)
            : base(new StructureIdUserIdEventKey(structureId, userId))
        {
            StructureId = structureId;
            UserId = userId;
        }

        public override IAcceptedEvent<UnregisterStructureUserCommand> CreateFrom(UnregisterStructureUserCommand command)
        {
            return new StructureUsersUnregistredEvent(command.StructureId, command.UserId);
        }
    }
}
