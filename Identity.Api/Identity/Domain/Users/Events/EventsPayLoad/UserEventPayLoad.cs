using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Events.EventsPayLoad
{
    public class UserEventPayLoad : IEventPayLoad
    {
        public Guid Id { get;}
        public String FirsName { get; }
        public string LastName { get; }
        public int Civility { get; }

        public UserEventPayLoad(Guid id, string firsName, string lastName, int civility)
        {
            Id = id;
            FirsName = firsName;
            LastName = lastName;
            Civility = civility;
        }
    }
}
