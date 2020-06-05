using Identity.Api.Contrats.AppServices.Responses;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppServices.Queries
{
    public class GetDetailledAppServiceQuery : IQuery<AppServiceDetailledResponse>
    {
        public Guid AppServiceId { get; }
        public GetDetailledAppServiceQuery(Guid appServiceId)
        {
            AppServiceId = appServiceId;
        }
    }
}
