using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Contrat.Users.Requests
{
    public class AssignRolesToUserRequest
    {
        public Guid UserId { get; set; }
        public List<Guid> Roles { get; set; }
        public AssignRolesToUserRequest()
        {
            Roles = new List<Guid>();
        }
    }
}
