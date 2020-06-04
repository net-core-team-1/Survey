using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Domain.Roles.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Events
{
    public class RoleRegistredEvent : AcceptedEventBase<RegisterRoleCommand>
    {
        public string Name { get; }
        public string Description { get; }
        public Guid CreatedBy { get; }
        public Guid AppServiceId { get; }
        public Guid StructureId { get; }
        public RoleRegistredEvent() : base()
        {
        }
        public RoleRegistredEvent(string name, string description, Guid createdBy, Guid appServiceId, Guid structureId)
            : this()
        {
            Name = name;
            Description = description;
            CreatedBy = createdBy;
            AppServiceId = appServiceId;
            StructureId = structureId;
        }

    }
}
