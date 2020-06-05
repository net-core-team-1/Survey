using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrats.AppServices.Responses
{
    public class AppServiceDetailledResponse
    {
        public Guid AppServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<Guid, string> Roles { get; set; }
        public Dictionary<Guid, string> Features { get; set; }
        public AppServiceDetailledResponse()
        {
            Roles = new Dictionary<Guid, string>();
            Features = new Dictionary<Guid, string>();
        }
    }
}
