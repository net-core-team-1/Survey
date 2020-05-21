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
    public class RoleRegistrationRejectedEvent : RejectedEventBase<RegisterRoleCommand>
    {
        public RoleRegistrationRejectedEvent() : base()
        {
        }
        private RoleRegistrationRejectedEvent(string reason, string code, RegisterRoleCommand command)
         : base(new RoleNameEventKey(command.Name), reason, code, command)
        {
        }
        public override IRejectedEvent<RegisterRoleCommand> CreateFrom(string reason, string code, RegisterRoleCommand command)
        {
            return new RoleRegistrationRejectedEvent(reason, code, command);
        }
    }
}
