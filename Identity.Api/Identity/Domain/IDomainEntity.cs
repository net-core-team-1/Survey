using Common.Types.Types.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain
{
    public interface IDomainEntity
    {
        List<IEvent> Events { get; set; }
    }
}
