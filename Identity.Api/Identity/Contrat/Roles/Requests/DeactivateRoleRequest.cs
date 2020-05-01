using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Identity.Contrat.Roles.Requests
{
    public class DeactivateRoleRequest
    {
        public Guid DeletedBy { get; set; }
    }
}
