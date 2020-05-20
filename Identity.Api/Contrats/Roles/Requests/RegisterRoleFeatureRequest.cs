﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrats.Roles.Requests
{
    public class RegisterRoleFeatureRequest
    {
        public Guid RoleId { get; set; }
        public Guid FeatureId { get; set; }
        public Guid AssignedBy { get; set; }
    }
}