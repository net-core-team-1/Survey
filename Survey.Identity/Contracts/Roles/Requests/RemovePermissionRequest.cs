using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{ 
    public sealed class RemovePermissionRequest
    {
        public string Reason { get; set; }
        public Guid DeletedBy { get; set; }
    }
}
