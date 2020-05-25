using CSharpFunctionalExtensions;
using Survey.Auth;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survey.Transverse.Domain.Users
{
    public class User : BaseEntity
    {
        #region Fields 

        public virtual FullName FullName { get; private set; }
        public virtual Email Email { get; private set; }
        public virtual Password Password { get; private set; }
        public virtual DeleteInfo DeleteInfo { get; private set; }
        public virtual CreateInfo CreateInfo { get; private set; }

        public DateTime? LastConnexionOn { get; private set; }

        private readonly List<UserPermission> _userPermissions = new List<UserPermission>();

        public virtual IReadOnlyList<UserPermission> UserPermissions => _userPermissions.ToList();


        #endregion

        #region Ctor 
        protected User()
        {
        }

        public User(FullName fullName, Email email, Password password, List<Guid> permissions)
        {

            FullName = fullName;
            Email = email;
            Password = password;
            CreateInfo = CreateInfo.Create().Value;
            DeleteInfo = DeleteInfo.Create().Value;
            EditPermissions(permissions, true);
        }

        #endregion

        #region Methods 

        public void Unregister(DeleteInfo deletionObj)
        {
            this.MarkAsDeleted(deletionObj);
        }

        public void EditUser(FullName fullName, Email email, List<Guid> permissions = null, bool deleteExisting = false)
        {
            this.EditPersonalInfo(fullName, email);
            this.EditPermissions(permissions, deleteExisting);

        }
        private void EditPersonalInfo(FullName fullName, Email email)
        {
            if (this.FullName != fullName)
                this.FullName = fullName;

            if (this.Email != email)
                this.Email = email;
        }
        private void EditPermissions(List<Guid> permissions, bool deleteExisting = false)
        {
            List<Guid> permissionToAdd = permissions.Where(a => _userPermissions.Where(b => b.Permission.Id == a).Count() == 0).ToList();
            List<UserPermission> userPermissionToDelete = _userPermissions.Where(a => permissions.Where(b => b == a.Permission.Id).Count() == 0)
                .ToList();

            if (userPermissionToDelete.Count() != 0)
                userPermissionToDelete.ForEach(a => _userPermissions.Remove(a));
            if (permissionToAdd.Count() != 0)
                permissionToAdd.ForEach(a => _userPermissions.Add(UserPermission.Create(this.Id, a)));
        }

        public void SetPassword(Password password)
        {
            Password = password;
        }

        public bool VerifyPassword(string password, IEncrypter encrypter)
        {
            return Password.Equals(encrypter.GetHash(password, Password.PasswordSalt));
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
