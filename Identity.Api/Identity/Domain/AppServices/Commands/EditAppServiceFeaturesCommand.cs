using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppServices.Commands
{
    public class EditAppServiceFeaturesCommand : ICommand
    {
        public Guid AppServiceId { get; }
        public List<Guid> Features { get; }

        public EditAppServiceFeaturesCommand(Guid appServiceId, List<Guid> features)
        {
            AppServiceId = appServiceId;
            Features = features;
        }
    }
}
