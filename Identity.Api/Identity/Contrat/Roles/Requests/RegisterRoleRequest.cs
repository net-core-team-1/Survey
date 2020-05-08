using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Identity.Contrat.Roles.Requests
{
    public sealed class RegisterRoleRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CreatedBy { get; set; }

        //public List<Guid> Features { get; set; }

        public RegisterRoleRequest()
        {
            //Features = new List<Guid>();
        }
    }
}
