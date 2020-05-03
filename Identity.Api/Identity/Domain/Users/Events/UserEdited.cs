using Common.Types.Types.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Events
{
    public class UserEdited : IEvent
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int CivilityId { get; }

        public UserEdited(Guid id, string firstName, string lastName, int civilityId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CivilityId = civilityId;
        }
    }
}
