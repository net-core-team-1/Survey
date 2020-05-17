using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structure.Commands
{
    public class EditStructureUsersCommand : ICommand
    {
        public Guid StructureId { get; }
        public Guid AssignedBy { get; }
        public List<Guid> Users { get; }

        public EditStructureUsersCommand(Guid structureId, Guid assignedBy, List<Guid> users)
        {
            StructureId = structureId;
            AssignedBy = assignedBy;
            Users = users;
        }
    }
}
