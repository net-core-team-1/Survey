﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrats.Users.Requests
{
    public class UnregisterUserRoleRequest
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
