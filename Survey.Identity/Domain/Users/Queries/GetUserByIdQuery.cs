using Survey.Common.Types;
using Survey.Identity.Contracts;
using System;

namespace Survey.Identity.Domain.Users.Queries
{
    public sealed class GetUserByIdQuery:IQuery<UserResponse>
    {
        public Guid Id { get;private set; }
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
