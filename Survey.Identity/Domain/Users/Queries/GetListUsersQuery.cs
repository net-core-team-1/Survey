using Survey.Common.Types;
using Survey.Identity.Contracts;
using System.Collections.Generic;

namespace Survey.Identity.Domain.Users.Queries
{
    public sealed class GetListUsersQuery:IQuery<List<UserListResponse>>
    {
        public GetListUsersQuery()
        {

        }
    }
}
