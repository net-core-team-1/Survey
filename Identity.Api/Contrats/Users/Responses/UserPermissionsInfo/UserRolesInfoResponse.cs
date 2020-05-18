using Identity.Api.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrats.Users.Responses.UserPermissionsInfo
{
    public class UserRolesInfoResponse
    {
        public Guid ServiceId { get; set; }
        public Guid RoleId { get; set; }
        public String Name { get; set; }
        public Dictionary<Guid, string> Features { get; set; }

        public long RoleFeaturesCount => Features.Count();

        public UserRolesInfoResponse()
        {
            Features = new Dictionary<Guid, string>();
        }
    }
}
