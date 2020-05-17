using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrats.Structures.Requests
{
    public class UnregisterUserStructureRequest
    {
        public Guid StructureId { get; set; }
        public Guid UserId { get; set; }
    }
}
