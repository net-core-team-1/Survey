using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Identity.Domain.AppServices.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppServices.Events
{
    public class AppServiceDeletedEvent : AcceptedEventBase<DeleteAppServiceCommand>
    {
        public Guid AppServiceId { get; }
        public Guid DeletedBy { get; }
        public AppServiceDeletedEvent()
        {

        }

        public AppServiceDeletedEvent(Guid appServiceId, Guid deletedBy)
            : base(new AppServiceIdKey(appServiceId))
        {
            AppServiceId = appServiceId;
            DeletedBy = deletedBy;
        }
    }
}
