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

        public User(FullName fullName, string email, List<Guid> roles)
        {

            UserName = email;
            FullName = fullName;
            Email = email;
            CreateInfo = CreateInfo.Create().Value;
            DeleteInfo = DeleteInfo.Create().Value;
            AssignRoles(roles);
        }

        #endregion 

        #region Methods 

        private void AssignRoles(List<Guid> roles)
        {
            List<Guid> toAdd = roles.Where(a => _userRoles.Where(b => b.RoleId == a).Count() == 0).ToList();

            if (toAdd.Count() != 0)
                toAdd.ForEach(a => _userRoles.Add(UserRole.Create(this.Id, a)));
        }
        private void RemoveRolesBaseOnNewRoles(List<Guid> roles)
        {
            List<UserRole> toRemove = _userRoles.Where(a => roles.Where(b => b == a.RoleId).Count() == 0)
                .ToList();

            if (toRemove.Count() != 0)
                toRemove.ForEach(a => _userRoles.Remove(a));
        }
        public void Unregister(DeleteInfo deleteInfo)
        {
            this.MarkAsDeleted(deleteInfo);
        }

        public void EditUser(FullName fullName, List<Guid> roles = null)
        {
            this.EditPersonalInfo(fullName);
            this.EditRoles(roles);

        }
        private void EditPersonalInfo(FullName fullName)
        {
            if (this.FullName != fullName)
                this.FullName = fullName;
        }
        private void EditRoles(List<Guid> roles)
        {
            RemoveRolesBaseOnNewRoles(roles);

            AssignRoles(roles);
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
