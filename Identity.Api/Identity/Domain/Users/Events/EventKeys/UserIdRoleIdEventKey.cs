using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Events.EventKeys
{
    public class UserIdRoleIdEventKey : IEventKey
    {
        public string Key { get; }
        public string KeyDescription { get; }

        public UserIdRoleIdEventKey(Guid userId, Guid roleId)
        {
            Key = $"{userId.ToString()}_{roleId.ToString()}";
            KeyDescription = "UserId_RoleId";
        }
    }
}
