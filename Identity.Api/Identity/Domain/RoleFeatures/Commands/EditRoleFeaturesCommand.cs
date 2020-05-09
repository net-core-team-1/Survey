using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.RoleFeatures.Commands
{
    public class EditRoleFeaturesCommand : ICommand
    {
        public Guid RoleId { get; }
        public List<Guid> Features { get; }
        public Guid AssignedBy { get; }

        public EditRoleFeaturesCommand(Guid roleId, List<Guid> features, Guid assignedBy)
        {
            RoleId = roleId;
            Features = features;
            AssignedBy = assignedBy;
        }
    }
}
