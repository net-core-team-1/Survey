using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{ 
    public class DeactivateRoleRequest
    {
        public Guid Id { get; set; }
        public Guid DeletedBy { get; set; }
    }
}
