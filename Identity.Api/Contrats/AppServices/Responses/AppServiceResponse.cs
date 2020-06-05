using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrats.AppServices.Responses
{
    public class AppServiceResponse
    {
        public Guid AppServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
