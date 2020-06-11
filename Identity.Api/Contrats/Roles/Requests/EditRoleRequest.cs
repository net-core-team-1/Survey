using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Contrat.Roles.Requests
{
    public sealed class EditRoleRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid AppServiceId { get; set; }

        public EditRoleRequest()
        {
        }
    }
}
