using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppServices.Commands
{
    public class DisableAppServiceCommand : ICommand
    {
        public Guid AppServiceId { get; }
        public string Reason { get; }
        public Guid DisableddBy { get; }

        public DisableAppServiceCommand(Guid appServiceId, string reason, Guid disableddBy)
        {
            AppServiceId = appServiceId;
            Reason = reason;
            DisableddBy = disableddBy;
        }
    }
}
