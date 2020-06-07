﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Contracts.EntityLevels.Requests
{
    public class CreateEntityRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CreatedBy { get; set; }
        //public Guid ParentId { get; set; }
        //public Guid LevelId { get; set; }
        public string Code { get; set; }
    }
}
