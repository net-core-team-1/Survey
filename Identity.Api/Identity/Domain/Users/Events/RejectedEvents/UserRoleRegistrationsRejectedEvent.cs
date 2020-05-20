using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Domain.Users.Events.EventKeys;
using Survey.Common.CQRS.Events;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Events.RejectedEvents
{
    public class UserRoleRegistrationsRejectedEvent : RejectedEventBase<RegisterUserRoleCommand>
    {
        public UserRoleRegistrationsRejectedEvent() : base() { }
        private UserRoleRegistrationsRejectedEvent(string reason, string code, RegisterUserRoleCommand command)
            : base(new UserIdRoleIdEventKey(command.UserId, command.RoleId), reason, code, command)
        {
        }
        public override IRejectedEvent<RegisterUserRoleCommand> CreateFrom(string reason, string code, RegisterUserRoleCommand command)
        {
            return new UserRoleRegistrationsRejectedEvent(reason, code, command);
        }
    }
}
