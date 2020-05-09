using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Contrat.Roles.Requests
{
    public class EditRoleFeaturesRequest
    {
        public Guid RoleId { get; set; }
        public List<Guid> Features { get; set; }
        public Guid AssignedBy { get; set; }

    }
}
