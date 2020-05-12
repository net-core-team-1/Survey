using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrat.Features.Requests
{
    public class UnregisterFeatureRequest
    {
        public Guid featureId { get; set; }
        public Guid DeletedBy { get; set; }
        public String Reason { get; set; }
    }
}
