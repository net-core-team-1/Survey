using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Contrat.Roles.Responses
{
    public sealed class RoleListResponse
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public Guid ServiceId { get; set; }
    }
}
