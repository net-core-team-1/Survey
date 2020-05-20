using Common.Types.Types.Events;
using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Domain.Users.Events.EventKeys;
using Survey.Common.CQRS.Events;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Events
{
    public class UserRoleUnregistredEvent : AcceptedEventBase<UnregisterUserRoleCommand>
    {
        public Guid UserId { get; }
        public Guid RoleId { get; }

        public UserRoleUnregistredEvent(Guid userId, Guid roleId)
            : base(new UserIdRoleIdEventKey(userId, roleId))
        {
            UserId = userId;
            RoleId = roleId;
        }

        public UserRoleUnregistredEvent() : base() { }

        public override IAcceptedEvent<UnregisterUserRoleCommand> CreateFrom(UnregisterUserRoleCommand command)
        {
            return new UserRoleUnregistredEvent(command.UserId, command.RoleId);
        }
    }
}
