using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{
    public class DeactivateFeatureRequest
    {
        public Guid DeletedBy { get; set; }
    }
}
