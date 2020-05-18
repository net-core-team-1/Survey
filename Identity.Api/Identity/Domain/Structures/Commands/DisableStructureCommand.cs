using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structures.Commands
{
    public class DisableStructureCommand : ICommand
    {
        public Guid StructureId { get; }
        public string Reason { get; }
        public Guid DisabledBy { get; }
        public DisableStructureCommand(Guid structureId, string reason, Guid disabledBy)
        {
            StructureId = structureId;
            Reason = reason;
            DisabledBy = disabledBy;
        }
    }
}
