using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrat.AppServices.Requests
{
    public class EditAppServiceFeaturesRequest
    {
        public Guid AppServiceId { get; set; }
        public List<Guid> Features { get; set; }
    }
}
