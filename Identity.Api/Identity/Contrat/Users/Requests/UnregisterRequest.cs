using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Contrat.Users.Requests
{
    public class UnregisterRequest
    {
        public Guid By { get; set; }
        public string Reason { get; set; }
    }
}
