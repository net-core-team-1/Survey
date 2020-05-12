using Identity.Api.Contrat.Features.Responses;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Queries
{
    public class GetFeatureQuery : IQuery<FeatureResponse>
    {
        public Guid FeatureId { get; }
        public GetFeatureQuery(Guid featureId)
        {
            FeatureId = featureId;
        }
    }
}
