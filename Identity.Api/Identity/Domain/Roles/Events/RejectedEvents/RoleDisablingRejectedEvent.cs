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
    public class RoleDisablingRejectedEvent : RejectedEventBase<DisableRoleCommand>
    {
        public RoleDisablingRejectedEvent() : base()
        {
        }
        private RoleDisablingRejectedEvent(string reason, string code, DisableRoleCommand command)
          : base(new RoleIdEventKey(command.Id), reason, code, command)
        {
        }

        public override IRejectedEvent<DisableRoleCommand> CreateFrom(string reason, string code, DisableRoleCommand command)
        {
            return new RoleDisablingRejectedEvent(reason, code, command);
        }
    }
}
