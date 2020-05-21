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
    public class RoleFeatureUnregistrationRejectedEvent : RejectedEventBase<UnregisterRoleFeatureCommand>
    {
        public RoleFeatureUnregistrationRejectedEvent() : base()
        {
        }
        private RoleFeatureUnregistrationRejectedEvent(string reason, string code, UnregisterRoleFeatureCommand command)
         : base(new RoleIdFeatureIdEventKey(command.RoleId, command.FeatureId), reason, code, command)
        {
        }
        public override IRejectedEvent<UnregisterRoleFeatureCommand> CreateFrom(string reason, string code, UnregisterRoleFeatureCommand command)
        {
            return new RoleFeatureUnregistrationRejectedEvent(reason, code, command);
        }
    }
}
