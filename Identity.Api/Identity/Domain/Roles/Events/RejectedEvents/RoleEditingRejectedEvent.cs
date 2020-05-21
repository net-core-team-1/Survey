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
    public class RoleEditingRejectedEvent : RejectedEventBase<EditRoleCommand>
    {
        public RoleEditingRejectedEvent() : base()
        {
        }
        private RoleEditingRejectedEvent(string reason, string code, EditRoleCommand command)
         : base(new RoleIdEventKey(command.Id), reason, code, command)
        {
        }
        public override IRejectedEvent<EditRoleCommand> CreateFrom(string reason, string code, EditRoleCommand command)
        {
            return new RoleEditingRejectedEvent(reason, code, command);
        }
    }
}
