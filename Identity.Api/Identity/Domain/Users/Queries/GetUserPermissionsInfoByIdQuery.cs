using Identity.Api.Contrats.Users.Responses.UserInfo;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Queries
{
    public class GetUserPermissionsInfoByIdQuery : IQuery<UserPermissionInfoResponse>
    {
        public Guid UserId { get; }

        public GetUserPermissionsInfoByIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
