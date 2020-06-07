using Survey.CQRS.Events;
using Survey.Identity.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Users.Events
{
    public class UserDeleted:IEvent
    {
        public Guid Id { get;private set; }
        public DateTime OccuredAt { get; set; }
        public Guid UserId { get;  }
        public string Reason { get;  }
        public DateTime DeletedAt { get;  }
        public UserDeleted(Guid userd,string reason,DateTime at)
        {
            Id = Guid.NewGuid();
            OccuredAt = DateTime.UtcNow;
            UserId = userd;
            Reason = reason;
            DeletedAt = at;
        }
    }
}
