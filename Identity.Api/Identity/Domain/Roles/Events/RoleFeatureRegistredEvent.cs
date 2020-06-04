using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Domain.Roles.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Events
{
    public class RoleFeatureRegistredEvent : AcceptedEventBase<RegisterRoleFeatureCommand>
    {
        public Guid RoleId { get; }
        public Guid FeatureId { get; }
        public Guid AssignedBy { get; }
        public RoleFeatureRegistredEvent() : base()
        {
        }

        public RoleFeatureRegistredEvent(Guid roleId, Guid featureId, Guid assignedBy)
            : this()
        {
            RoleId = roleId;
            FeatureId = featureId;
            AssignedBy = assignedBy;
        }

    }
}
