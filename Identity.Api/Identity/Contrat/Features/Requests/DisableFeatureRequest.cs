using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Contrat.Features.Requests
{
    public class DisableFeatureRequest
    {
        public Guid featureId { get; set; }
        public Guid DisabledBy { get; set; }
        public String Reason { get; set; }
    }
}
