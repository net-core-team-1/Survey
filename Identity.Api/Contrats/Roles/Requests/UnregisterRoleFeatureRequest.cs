using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrats.Roles.Requests
{
    public class UnregisterRoleFeatureRequest
    {
        public Guid RoleId { get; set; }
        public Guid FeatureId { get; set; }
    }
}
