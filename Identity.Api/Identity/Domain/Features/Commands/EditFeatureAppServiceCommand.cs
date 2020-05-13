using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Commands
{
    public class EditFeatureAppServiceCommand : ICommand
    {
        public Guid AppServiceId { get;  }
        public Guid FeatureId { get; }

        public EditFeatureAppServiceCommand(Guid appServiceId, Guid featureId)
        {
            AppServiceId = appServiceId;
            FeatureId = featureId;
        }
    }
}
