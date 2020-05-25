using Microsoft.AspNetCore.Identity;
using Survey.Identity.Domain.Roles;
using System;

namespace Survey.Identity.Domain.Users
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public DateTime AssociatedOn { get; set; }
        public byte[] Timestamp { get; private set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }

        public UserRole()
        {

        }
        private UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
            AssociatedOn = DateTime.Now;
        }
        public static UserRole Create(Guid userId, Guid permissionId)
        {
            UserRole userPermission = new UserRole(userId, permissionId);
            return userPermission;
        }
    }
}
