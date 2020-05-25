using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{
   public class FeatureListResponse
    {
        public Guid Id { get; set; }
        public String Label { get; set; }
        public String Action { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
