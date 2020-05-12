using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structure.Commands
{
    public class EditStructureCommand : ICommand
    {
        public Guid StructureId { get; }
        public string Name { get; }
        public string Description { get; }

        public EditStructureCommand(Guid structureId, string name, string description)
        {
            StructureId = structureId;
            Name = name;
            Description = description;
        }
    }
}
