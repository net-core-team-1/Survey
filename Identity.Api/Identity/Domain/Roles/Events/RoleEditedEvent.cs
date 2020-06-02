using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Domain.Roles.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Events
{
    public class RoleEditedEvent : AcceptedEventBase<EditRoleCommand>
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public Guid AppServiceId { get; }
        public RoleEditedEvent() : base()
        {
        }

        public RoleEditedEvent(Guid id, string name, string description, Guid appServiceId)
            : base(new RoleIdEventKey(id))
        {
            Id = id;
            Name = name;
            Description = description;
            AppServiceId = appServiceId;
        }

    }
}
