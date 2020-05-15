using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Commands
{
    public class UnregisterRoleFeatureCommand : ICommand
    {
        public Guid RoleId { get; }
        public Guid FeatureId { get; }

        public UnregisterRoleFeatureCommand(Guid roleId, Guid featureId)
        {
            RoleId = roleId;
            FeatureId = featureId;
        }
    }
}
