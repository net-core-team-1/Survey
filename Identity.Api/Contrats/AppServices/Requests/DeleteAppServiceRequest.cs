﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrat.AppServices.Requests
{
    public class DeleteAppServiceRequest
    {
        public Guid AppServiceId { get; set; }
        public string Reason { get; set; }
        public Guid DeletedBy { get; set; }

    }
}
