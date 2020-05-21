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
    public class RoleFeatureEditingRejectedEvent : RejectedEventBase<EditRoleFeatureCommand>
    {
        public RoleFeatureEditingRejectedEvent() : base()
        {
        }
        private RoleFeatureEditingRejectedEvent(string reason, string code, EditRoleFeatureCommand command)
            :base(new RoleIdEventKey(command.RoleId), reason, code, command)
        {
        }
        public override IRejectedEvent<EditRoleFeatureCommand> CreateFrom(string reason, string code, EditRoleFeatureCommand command)
        {
            return new RoleFeatureEditingRejectedEvent(reason, code, command);
        }
    }
}
