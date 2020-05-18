using Identity.Api.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrats.Structures.Responses
{
    public class StructureUserResponse : ResponseBase
    {
        public Guid StructureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Guid> Users { get; set; }

        public override long Count => Users.Count();

        public StructureUserResponse()
        {
            Users = new List<Guid>();
        }
    }
}
