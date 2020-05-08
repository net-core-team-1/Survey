using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Users
{
    public class User : IdentityUser<Guid>
    {
        #region Fields 

        public virtual FullName FullName { get; private set; }
        public virtual DeleteInfo DeleteInfo { get; private set; }
        public virtual CreateInfo CreateInfo { get; private set; }

        public byte[] Timestamp { get; private set; }


        public DateTime? LastConnexionOn { get; private set; }

        private readonly List<UserRole> _userRoles = new List<UserRole>();

        public virtual IReadOnlyList<UserRole> UserRoles => _userRoles.ToList();


        #endregion

        #region Ctro
        protected User()
        {
        }

        public User(FullName fullName, string email,  List<Guid> roles)
        {

            UserName = email;
            FullName = fullName;
            Email = email;
            CreateInfo = CreateInfo.Create().Value;
            DeleteInfo = DeleteInfo.Create().Value;
            EditRoles(roles, true);
        }

        #endregion 

        #region Methods 

        public void Unregister(DeleteInfo deletionObj)
        {
            this.MarkAsDeleted(deletionObj);
        }

        public void EditUser(FullName fullName, List<Guid> permissions = null, bool deleteExisting = false)
        {
            this.EditPersonalInfo(fullName);
            this.EditRoles(permissions, deleteExisting);

        }
        private void EditPersonalInfo(FullName fullName)
        {
            if (this.FullName != fullName)
                this.FullName = fullName;
        }
        private void EditRoles(List<Guid> roles, bool deleteExisting = false)
        {
            List<Guid> rolesToAdd = roles.Where(a => _userRoles.Where(b => b.RoleId == a).Count() == 0).ToList();
            List<UserRole> userRolesToDelete = _userRoles.Where(a => roles.Where(b => b == a.RoleId).Count() == 0)
                .ToList();

            if (userRolesToDelete.Count() != 0)
                userRolesToDelete.ForEach(a => _userRoles.Remove(a));
            if (rolesToAdd.Count() != 0)
                rolesToAdd.ForEach(a => _userRoles.Add(UserRole.Create(this.Id, a)));
        }


        public void SetLastConnexionDate()
        {
            this.LastConnexionOn = DateTime.Now;
        }

        private void MarkAsDeleted(DeleteInfo deletionObj)
        {
            DeleteInfo = deletionObj;
        }


        #endregion

    }
}
