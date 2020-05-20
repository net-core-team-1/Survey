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
    public class UserRoleUnregistrationRejectedEvent : RejectedEventBase<UnregisterUserRoleCommand>
    {
        public UserRoleUnregistrationRejectedEvent() : base() { }
        private UserRoleUnregistrationRejectedEvent(string reason, string code, UnregisterUserRoleCommand command)
             : base(new UserIdRoleIdEventKey(command.UserId, command.RoleId), reason, code, command)
        {
        }
        public override IRejectedEvent<UnregisterUserRoleCommand> CreateFrom(string reason, string code, UnregisterUserRoleCommand command)
        {
            return new UserRoleUnregistrationRejectedEvent(reason, code, command);
        }
    }
}
