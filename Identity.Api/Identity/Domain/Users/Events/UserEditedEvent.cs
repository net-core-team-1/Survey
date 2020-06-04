using Common.Types.Types.Events;
using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Domain.Users.Events.EventKeys;
using Survey.Common.CQRS.Events;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Events
{
    public class UserEditedEvent : AcceptedEventBase<EditUserCommand>
    {
        public Guid Id { get; }
        public String FirsName { get; }
        public string LastName { get; }
        public int Civility { get; }

        public UserEditedEvent(Guid id, string firsName, string lastName, int civility)
             : this()
        {
            Id = id;
            FirsName = firsName;
            LastName = lastName;
            Civility = civility;
        }

        public UserEditedEvent() : base() { }

    }
}
