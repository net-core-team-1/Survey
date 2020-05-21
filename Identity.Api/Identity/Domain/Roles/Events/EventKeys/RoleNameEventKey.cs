using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Events.EventKeys
{
    public class RoleNameEventKey:IEventKey
    {
        public string Key { get; }
        public string KeyDescription { get; }

        public RoleNameEventKey(string roleName)
        {
            Key = roleName.ToString();
            KeyDescription = "RoleName";
        }
    }
}
