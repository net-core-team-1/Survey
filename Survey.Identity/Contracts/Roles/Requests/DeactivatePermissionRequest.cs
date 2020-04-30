using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{ 
    public class DeactivatePermissionRequest
    {
        public Guid DeletedBy { get; set; }
    }
}
