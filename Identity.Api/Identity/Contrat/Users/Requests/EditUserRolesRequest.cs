using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Contrat.Users.Requests
{
    public class EditUserRolesRequest
    {
        public Guid UserId { get; set; }
        public List<Guid> Roles { get; set; }
        public EditUserRolesRequest()
        {
            Roles = new List<Guid>();
        }
    }
}
