using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Commands
{
    public class RegisterRoleFeatureCommand : ICommand
    {
        public Guid AssignedBy { get; }
        public Guid RoleId { get; }
        public List<Guid> Features { get; }

        public RegisterRoleFeatureCommand(Guid assignedBy, Guid roleId, List<Guid> features)
        {
            AssignedBy = assignedBy;
            RoleId = roleId;
            Features = features;
        }
    }
}
