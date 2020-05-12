using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppServices.Commands
{
    public class DeleteAppServiceCommand : ICommand
    {
        public Guid AppServiceId { get; }
        public string Reason { get; }
        public Guid DeletedBy { get; }

        public DeleteAppServiceCommand(Guid appServiceId, string reason, Guid deletedBy)
        {
            AppServiceId = appServiceId;
            Reason = reason;
            DeletedBy = deletedBy;
        }
    }
}
