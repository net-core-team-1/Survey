using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Contrat.Roles.Requests
{
    public sealed class RegisterRoleRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid AppServiceId { get; set; }
        public Guid StructureId { get; set; }

        public RegisterRoleRequest()
        {
        }
    }
}
