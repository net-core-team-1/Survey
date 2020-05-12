using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrat.Features.Responses
{
    public class FeatureResponse
    {
        public Guid FeatureId { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string ControllerName { get; set; }
        public string ControllerActionName { get; set; }
        public string Action { get; set; }
    }
}
