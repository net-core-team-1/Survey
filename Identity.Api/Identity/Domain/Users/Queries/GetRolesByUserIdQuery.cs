using Identity.Api.Identity.Contrat.Users.Responses;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Queries
{
    public class GetRolesByUserIdQuery : IQuery<UserRolesResponse>
    {
        public Guid UserId { get; }

        public GetRolesByUserIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
