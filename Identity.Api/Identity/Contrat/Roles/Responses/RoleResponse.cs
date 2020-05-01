using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Identity.Contrat.Roles.Responses
{
    public sealed class RoleResponse
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
    }
}
