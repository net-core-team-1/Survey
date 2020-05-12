using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrat.Structures.Requests
{
    public class EditStructureRequest
    {
        public Guid StructureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
