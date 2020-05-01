using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{ 
    public sealed class RemoveRoleRequest
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
        public Guid DeletedBy { get; set; }
    }
}
