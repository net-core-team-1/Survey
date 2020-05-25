using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Contracts.EntityLevels.Requests
{
    public class AddEntityLevelRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ParentId { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
