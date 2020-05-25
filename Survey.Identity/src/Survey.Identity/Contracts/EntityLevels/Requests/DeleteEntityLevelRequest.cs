using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Contracts.EntityLevels.Requests
{
    public class DeleteEntityLevelRequest
    {
        public Guid Id { get; set; }
        public Guid By { get; set; }
        public string Reason { get; set; }
    }
}
