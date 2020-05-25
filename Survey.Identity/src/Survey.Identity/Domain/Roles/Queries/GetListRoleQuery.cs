using Survey.CQRS.Commands;
using Survey.Identity.Contracts;
using System.Collections.Generic;

namespace Survey.Identity.Domain.Roles.Queries
{
    public sealed class GetListRoleQuery : IQuery<List<RoleListResponse>>
    {
        public GetListRoleQuery()
        {

        }
    }
}
