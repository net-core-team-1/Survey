using Identity.Api.Identity.Domain.Structures.Commands;
using Identity.Api.Identity.Domain.Structures.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structures.Events
{
    public class StructureRegistredEvent : AcceptedEventBase<RegisterStructureCommand>
    {
        public string Name { get; }
        public string Description { get; }
        public Guid CreatedBy { get; }
        public StructureRegistredEvent() : base()
        {
        }

        public StructureRegistredEvent(string name, string description, Guid createdBy)
            : base(new StructureNameEventKey(name))
        {
            Name = name;
            Description = description;
            CreatedBy = createdBy;
        }

        public override IAcceptedEvent<RegisterStructureCommand> CreateFrom(RegisterStructureCommand command)
        {
            return new StructureRegistredEvent(command.Name, command.Description, command.CreatedBy);
        }
    }
}
