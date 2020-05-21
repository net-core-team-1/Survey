using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Domain.Roles.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Events
{
    public class RoleFeatureEditedEvent : AcceptedEventBase<EditRoleFeatureCommand>
    {
        public Guid AssignedBy { get; }
        public Guid RoleId { get; }
        public List<Guid> Features { get; }
        public RoleFeatureEditedEvent()
            : base()
        {
        }
        public RoleFeatureEditedEvent(Guid assignedBy, Guid roleId, List<Guid> features)
            : base(new RoleIdEventKey(roleId))
        {
            AssignedBy = assignedBy;
            RoleId = roleId;
            Features = features;
        }

        public override IAcceptedEvent<EditRoleFeatureCommand> CreateFrom(EditRoleFeatureCommand command)
        {
            return new RoleFeatureEditedEvent(command.AssignedBy, command.RoleId, command.Features);
        }
    }
}
