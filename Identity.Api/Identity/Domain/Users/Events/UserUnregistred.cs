using Common.Types.Types.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Events
{
    public class UserUnregistred : IEvent
    {
        public Guid UserId { get; }
        public string Reason { get; }
        public DateTime DeletedOn { get; }

        public UserUnregistred(Guid userId, string reason, DateTime deletedOn)
        {
            UserId = userId;
            Reason = reason;
            DeletedOn = deletedOn;
        }
    }
}
