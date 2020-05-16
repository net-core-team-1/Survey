using Identity.Api.Contrats.Features.Responses;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Queries
{
    public class GetListFeaturesByRoleIdQuery : IQuery<FeaturesListResponse>
    {
        public Guid RoleId { get; }

        public GetListFeaturesByRoleIdQuery(Guid roleId)
        {
            RoleId = roleId;
        }
    }
}
