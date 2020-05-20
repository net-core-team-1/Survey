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
    public class UserRoleRegistredEvent : AcceptedEventBase<RegisterUserRoleCommand>
    {
        public Guid UserId { get; }
        public Guid RoleId { get; }

        public UserRoleRegistredEvent(Guid userId, Guid roleId)
              : base(new UserIdRoleIdEventKey(userId, roleId))
        {
            UserId = userId;
            RoleId = roleId;
        }

        public UserRoleRegistredEvent() : base() { }

        public override IAcceptedEvent<RegisterUserRoleCommand> CreateFrom(RegisterUserRoleCommand command)
        {
            return new UserRoleRegistredEvent(command.UserId, command.RoleId);
        }
    }
}
