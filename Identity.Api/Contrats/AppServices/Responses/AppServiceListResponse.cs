using Identity.Api.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrats.AppServices.Responses
{
    public class AppServiceListResponse : ResponseBase
    {
        public List<AppServiceResponse> Items { get; set; }

        public override Int64 Count => Items.Count();

        public AppServiceListResponse(List<AppServiceResponse> items)
        {
            Items = items;
        }
    }
}
