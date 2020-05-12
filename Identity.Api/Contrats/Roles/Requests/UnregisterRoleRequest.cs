using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Contrat.Roles.Requests
{
    public sealed class UnregisterRoleRequest
    {
        public Guid Id { get; set; }
        public Guid DeletedBy { get; set; }
        public DateTime DeleteOn { get; set; }
        public string Reason { get; set; }
    }
}
