using Survey.CQRS.Events;
using Survey.Identity.Events;
using System;

namespace Identity.Domain.Users.Events
{
    public sealed class UserRegistered : IEvent
    {
        public Guid Id { get; private set; }
        public DateTime OccuredAt { get; set; }

        public Guid UserId { get;  }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public DateTime CreatedOn { get;  }
        public UserRegistered(Guid userId, string firstName, string lastName, string email, DateTime createdOn)
        {
            Id = Guid.NewGuid();
            OccuredAt = DateTime.UtcNow;

            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CreatedOn = createdOn;
        }
    }
}
