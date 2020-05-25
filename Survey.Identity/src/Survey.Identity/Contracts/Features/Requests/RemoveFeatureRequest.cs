using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{
   public  class RemoveFeatureRequest
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
        public Guid DeletedBy { get; set; }
    }
}
