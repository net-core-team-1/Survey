using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppServices.Commands
{
    public class RegisterAppServiceFeatureCommand : ICommand
    {
        public Guid AppServiceId { get;  }
        public Guid FeatureId { get; }

        public RegisterAppServiceFeatureCommand(Guid appServiceId, Guid featureId)
        {
            AppServiceId = appServiceId;
            FeatureId = featureId;
        }
    }
}
