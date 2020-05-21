using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Domain.Roles.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Events
{
    public class RoleFeatureUnregistredEvent : AcceptedEventBase<UnregisterRoleFeatureCommand>
    {
        public Guid RoleId { get; }
        public Guid FeatureId { get; }
        public RoleFeatureUnregistredEvent():base()
        {
        }

        public RoleFeatureUnregistredEvent(Guid roleId, Guid featureId)
            :base(new RoleIdFeatureIdEventKey(roleId,featureId))
        {
            RoleId = roleId;
            FeatureId = featureId;
        }

        public override IAcceptedEvent<UnregisterRoleFeatureCommand> CreateFrom(UnregisterRoleFeatureCommand command)
        {
            return new RoleFeatureUnregistredEvent(command.RoleId, command.FeatureId);
        }
    }
}
