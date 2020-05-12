using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structure.Commands
{
    public class DeleteStructureCommand : ICommand
    {
        public Guid StructureId { get; }
        public string Reason { get; }
        public Guid DeletedBy { get; }

        public DeleteStructureCommand(Guid structureId, string reason, Guid deletedBy)
        {
            StructureId = structureId;
            Reason = reason;
            DeletedBy = deletedBy;
        }
    }
}
