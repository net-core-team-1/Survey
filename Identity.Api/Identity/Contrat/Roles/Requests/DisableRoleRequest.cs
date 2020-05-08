using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Identity.Contrat.Roles.Requests
{
    public class DisableRoleRequest
    {
        public Guid Id { get; set; }
        public Guid DisabledBy { get; set; }
    }
}
