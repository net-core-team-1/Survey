using Identity.Api.Identity.Contrat.Roles.Responses;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Queries
{
    public class GetRoleByIdQuery : IQuery<RoleResponse>
    {
        public Guid Id { get; }

        public GetRoleByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
