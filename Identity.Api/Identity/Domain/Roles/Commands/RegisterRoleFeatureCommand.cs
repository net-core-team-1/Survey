﻿using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Commands
{
    public class RegisterRoleFeatureCommand : ICommand
    {
        public Guid RoleId { get; }
        public Guid FeatureId { get; }
        public Guid AssignedBy { get; }
        public RegisterRoleFeatureCommand(Guid roleId, Guid featureId, Guid assignedBy)
        {
            RoleId = roleId;
            FeatureId = featureId;
            AssignedBy = assignedBy;
        }
    }
}
