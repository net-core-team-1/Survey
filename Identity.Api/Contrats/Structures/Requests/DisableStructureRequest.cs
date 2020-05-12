﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrat.Structures.Requests
{
    public class DisableStructureRequest
    {
        public Guid StructureId { get; set; }
        public string Reason { get; set; }
        public Guid DisabledBy { get; set; }
    }
}
