using Identity.Api.Common.Responses;
using Identity.Api.Contrat.Features.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrats.Features.Responses
{
    public class FeaturesListResponse : ResponseBase
    {
        public List<FeatureResponse> Items { get; set; }

        public override Int64 Count => Items.Count();

        public FeaturesListResponse(List<FeatureResponse> items)
        {
            Items = items;
        }
    }
}
