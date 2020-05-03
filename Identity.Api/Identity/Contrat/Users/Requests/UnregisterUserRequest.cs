using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Contrat.Users.Requests
{
    public class UnregisterUserRequest
    {
        public Guid UserId { get; set; }
        public string Reason { get; set; }
        public Guid DeletedBy { get; set; }
        public DateTime DeletedAt { get; set; }

        public UnregisterUserRequest()
        {
        }
    }
}
