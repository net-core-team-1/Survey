using Identity.Api.Contrats.Users.Responses.UserPermissionsInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Contrats.Users.Responses.UserInfo
{
    public class UserPermissionInfoResponse
    {
        public Guid UserId { get; set; }
        public String Name { get; set; }
        public int StructureCounts => Structures.Count();
        public int RoleCounts => Roles.Count();
        public Dictionary<Guid, string> Structures { get; set; }
        public List<UserRolesInfoResponse> Roles { get; set; }
        public UserPermissionInfoResponse()
        {
            Roles = new List<UserRolesInfoResponse>();
            Structures = new Dictionary<Guid, string>();
        }
    }
}
