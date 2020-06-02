using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppServices.Events.EventKeys
{
    public class AppServiceIdKey : IEventKey
    {
        public string Key { get; }
        public string KeyDescription { get; }

        public AppServiceIdKey(Guid serviceId)
        {
            Key = serviceId.ToString();
            KeyDescription = "AppServiceId";
        }
    }
}
