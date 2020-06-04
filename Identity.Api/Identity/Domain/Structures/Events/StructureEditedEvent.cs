using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structures.Events
{
    public class StructureEditedEvent : AcceptedEventBase<EditStructureCommand>
    {
        public Guid StructureId { get; }
        public string Name { get; }
        public string Description { get; }

        public StructureEditedEvent() : base()
        {
        }
        public StructureEditedEvent(Guid structureId, string name, string description)
            : this()
        {
            StructureId = structureId;
            Name = name;
            Description = description;
        }

    }
}
