using Survey.CQRS.Commands;
using Survey.Transverse.Contract.Users.Responses;
using System.Collections.Generic;

namespace Survey.Transverse.Domain.Users.Queries
{
    public sealed class GetListUsersQuery:IQuery<List<UserListResponse>>
    {
        public GetListUsersQuery()
        {

        }
    }
}
