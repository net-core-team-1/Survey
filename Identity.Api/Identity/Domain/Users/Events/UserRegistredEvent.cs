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
    public class UserRegistredEvent : AcceptedEventBase<RegisterUserCommand>
    {
        public string UserName { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public int CivilityId { get; }
        public Guid StructureId { get; }
        public List<Guid> Permissions { get; }

        public UserRegistredEvent(string userName, string firstName, string lastName, string email,
            int civilityId, Guid structureId, List<Guid> permissions)
            : this()
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CivilityId = civilityId;
            StructureId = structureId;
            Permissions = permissions;
        }

        public UserRegistredEvent() : base() { }

    }
}
