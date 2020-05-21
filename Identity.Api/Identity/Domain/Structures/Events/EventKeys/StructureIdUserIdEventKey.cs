using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structures.Events.EventKeys
{
    public class StructureIdUserIdEventKey:IEventKey
    {
        public string Key { get; }
        public string KeyDescription { get; }

        public StructureIdUserIdEventKey(Guid structureId, Guid userId)
        {
            Key = $"{structureId.ToString()}_{userId.ToString()}";
            KeyDescription = "StructureId_UserId";
        }
    }
}
