using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Identity.Contrat.Roles.Requests
{
    public sealed class RemoveRoleRequest
    {
        public string Reason { get; set; }
        public Guid DeletedBy { get; set; }
    }
}
