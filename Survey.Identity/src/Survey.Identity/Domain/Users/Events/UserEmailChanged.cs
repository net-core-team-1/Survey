using Survey.CQRS.Events;
using Survey.Identity.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Users.Events
{
    public class UserEmailChanged : IEvent
    {
        public Guid Id { get; private set; }
        public DateTime OccuredAt { get; set; }

        public Guid UserId { get;  }
        public string Email { get;  }
        public UserEmailChanged(Guid userId, string email)
        {
            Id = Guid.NewGuid();
            OccuredAt = DateTime.UtcNow;
            UserId = userId;
            Email = email;
        }
    }
}
