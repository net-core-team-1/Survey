using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Commands
{
    public class UnRegisterFeatureCommand : ICommand
    {
        public Guid FeatureId { get; }
        public Guid DeletedBy { get; }
        public String Reason { get; }

        public UnRegisterFeatureCommand(Guid featureId, Guid deletedBy, string reason)
        {
            this.FeatureId = featureId;
            DeletedBy = deletedBy;
            Reason = reason;
        }
    }
}
