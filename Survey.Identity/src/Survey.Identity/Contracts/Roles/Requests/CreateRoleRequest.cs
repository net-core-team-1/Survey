using Survey.Identity.Contracts.Features;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{
    public sealed class CreateRoleRequest
    {
        public string Name { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid EntityId { get; set; }
        public List<Guid> Features { get; set; }

        public CreateRoleRequest()
        {
            Features = new List<Guid>();
        }
    }
}
