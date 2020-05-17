using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrats.Structures.Requests
{
    public class EditStructureUsersRequest
    {
        public Guid StructureId { get; set; }
        public Guid AssignedBy { get; set; }
        public List<Guid> Users { get; set; }
    }
}
