﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{
   public sealed class EditRoleRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


    }
}
