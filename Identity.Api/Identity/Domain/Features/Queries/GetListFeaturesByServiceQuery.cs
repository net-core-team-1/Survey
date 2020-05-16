using Identity.Api.Contrat.Features.Responses;
using Identity.Api.Contrats.Features.Responses;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Queries
{
    public class GetListFeaturesByServiceQuery : IQuery<FeaturesListResponse>
    {
        public Guid ServiceId { get; }

        public GetListFeaturesByServiceQuery(Guid serviceId)
        {
            ServiceId = serviceId;
        }
    }
}
