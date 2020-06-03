using Common.Types.Types.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain
{
    public interface IDomainEntity
    {
        [NotMapped]
        List<IEvent> Events { get; set; }
    }
}
