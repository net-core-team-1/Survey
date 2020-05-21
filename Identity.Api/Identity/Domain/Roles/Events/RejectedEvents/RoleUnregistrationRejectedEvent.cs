using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Domain.Roles.Events.EventKeys;
using Identity.Api.Identity.Domain.Users.Events.RejectedEvents;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Events.RejectedEvents
{
    public class RoleUnregistrationRejectedEvent : RejectedEventBase<UnregisterRoleCommand>
    {
        public RoleUnregistrationRejectedEvent() : base()
        {
        }
        private RoleUnregistrationRejectedEvent(string reason, string code, UnregisterRoleCommand command)
            : base(new RoleIdEventKey(command.Id), reason, code, command)
        {
        }
        public override IRejectedEvent<UnregisterRoleCommand> CreateFrom(string reason, string code, UnregisterRoleCommand command)
        {
            return new RoleUnregistrationRejectedEvent(reason, code, command);
        }
    }
}
