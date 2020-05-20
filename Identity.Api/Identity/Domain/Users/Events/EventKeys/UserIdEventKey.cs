using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Events.EventKeys
{
    public class UserIdEventKey : IEventKey
    {
        public string Key { get; }
        public string KeyDescription { get; }

        public UserIdEventKey(Guid userId)
        {
            Key = userId.ToString();
            KeyDescription = "UserId";
        }
    }
}
