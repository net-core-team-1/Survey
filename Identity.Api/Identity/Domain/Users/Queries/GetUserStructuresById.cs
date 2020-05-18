using Identity.Api.Contrats.Users.Responses.UserStructures;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Queries
{
    public class GetUserStructuresById:IQuery<UserStructureResponse>
    {
        public Guid UserId { get; }

        public GetUserStructuresById(Guid userId)
        {
            UserId = userId;
        }
    }
}
