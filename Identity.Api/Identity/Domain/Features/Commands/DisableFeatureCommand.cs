using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Commands
{
    public class DisableFeatureCommand : ICommand
    {
        public Guid FeatureId { get; }
        public Guid DisabledBy { get; }
        public String Reason { get; }

        public DisableFeatureCommand(Guid featureId, Guid disabledBy, string reason)
        {
            this.FeatureId = featureId;
            DisabledBy = disabledBy;
            Reason = reason;
        }
    }
}
