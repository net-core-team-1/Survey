using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structures.Commands
{
    public class UnregisterStructureUserCommand : ICommand
    {
        public Guid StructureId { get; }
        public Guid UserId { get; }

        public UnregisterStructureUserCommand(Guid structureId, Guid userId)
        {
            StructureId = structureId;
            UserId = userId;
        }
    }
}
