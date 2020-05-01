﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Identity.Contrat.Roles.Requests
{
   public sealed class EditRoleRequest
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

        public List<Guid> Features { get; set; }

        public bool DeleteExistingFeatures { get; set; }

        public EditRoleRequest()
        {
            Features = new List<Guid>();
            DeleteExistingFeatures = false;
        }
    }
}
