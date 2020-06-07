using Survey.CQRS.Events;
using Survey.Identity.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Users.Events
{
    public class UserNameUpdated: IEvent
    {
        public Guid Id { get; private set; }
        public DateTime OccuredAt { get; set; }

        public Guid UserId { get;  }
        public string FirstName { get;  }
        public string LastName { get; }

        public UserNameUpdated(Guid userId,string firstName,string lastName)
        {
            Id = Guid.NewGuid();
            OccuredAt = DateTime.UtcNow;

            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
