using Survey.CQRS.Events;
using System;

namespace Transverse.Domain.Users.Events
{
    public sealed class UserRegistered : IEvent
    {
        public Guid Id { get; set; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public DateTime? CreatedOn { get; set; }
        public UserRegistered(Guid id,string firstName,string lastName,string email,DateTime? createdOn)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CreatedOn = createdOn;
        }
    }
}
