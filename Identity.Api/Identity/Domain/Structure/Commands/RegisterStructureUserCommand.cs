using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structure.Commands
{
    public class RegisterStructureUserCommand : ICommand
    {
        public Guid StructureId { get; }
        public Guid UserId { get; }

        public RegisterStructureUserCommand(Guid structureId, Guid userId)
        {
            StructureId = structureId;
            UserId = userId;
        }
    }
}
