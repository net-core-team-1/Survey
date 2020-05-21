using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structures.Events.EventKeys
{
    public class StructureNameEventKey : IEventKey
    {
        public string Key { get; }
        public string KeyDescription { get; }

        public StructureNameEventKey(string name)
        {
            Key = name.ToString();
            KeyDescription = "Structure Name";
        }
    }
}
