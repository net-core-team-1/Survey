using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrats.Roles.Requests
{
    public class RegisterRoleFeatureRequest
    {
        public Guid AssignedBy { get; set; }
        public Guid RoleId { get; set; }
        public List<Guid> Features { get; set; }
    }
}
