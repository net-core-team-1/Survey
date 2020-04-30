using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{
   public  class RemoveFeatureRequest
    {
        public string Reason { get; set; }
        public Guid DeletedBy { get; set; }
    }
}
