using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Identity.Domain.AppServices.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppServices.Events
{
    public class AppServiceDisabledEvent : AcceptedEventBase<DisableAppServiceCommand>
    {
        public Guid AppServiceId { get; }
        public Guid DisableddBy { get; }
        public AppServiceDisabledEvent():base()
        {
        }
        public AppServiceDisabledEvent(Guid appServiceId, Guid disableddBy)
            : this()
        {
            AppServiceId = appServiceId;
            DisableddBy = disableddBy;
        }

    }
}
