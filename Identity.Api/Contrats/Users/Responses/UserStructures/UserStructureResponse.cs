using Identity.Api.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrats.Users.Responses.UserStructures
{
    public class UserStructureResponse : ResponseBase
    {
        public Guid UserdId { get; set; }
        public List<Guid> Structures { get; set; }

        public override long Count => Structures.Count();

        public UserStructureResponse()
        {
            Structures = new List<Guid>();
        }
    }
}
