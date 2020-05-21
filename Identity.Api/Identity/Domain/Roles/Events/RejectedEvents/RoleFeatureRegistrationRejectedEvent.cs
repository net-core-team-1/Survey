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
    public class RoleFeatureRegistrationRejectedEvent : RejectedEventBase<RegisterRoleFeatureCommand>
    {
        public RoleFeatureRegistrationRejectedEvent() : base()
        {
        }
        private RoleFeatureRegistrationRejectedEvent(string reason, string code, RegisterRoleFeatureCommand command)
            : base(new RoleIdFeatureIdEventKey(command.RoleId, command.FeatureId), reason, code, command)
        {
        }
        public override IRejectedEvent<RegisterRoleFeatureCommand> CreateFrom(string reason, string code, RegisterRoleFeatureCommand command)
        {
            return new RoleFeatureRegistrationRejectedEvent(reason, code, command);
        }
    }
}
