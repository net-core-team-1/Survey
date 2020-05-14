using CSharpFunctionalExtensions;
using Identity.Api.Identity.Domain.AppServices;
using Identity.Api.Identity.Domain.AppUserRoles;
using Identity.Api.Identity.Domain.Civilities;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Structure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Identity.Api.Identity.Domain.Users
{
    public class AppUser : IdentityUser<Guid>
    {
        public virtual FullName FullName { get; protected set; }
        public virtual Civility Civility { get; protected set; }
        public virtual DeleteInfo DeleteInfo { get; protected set; }
        public virtual AppUserRoleCollection UserRoles { get; protected set; }
        public virtual StructureUsersCollection StructureUsers { get; protected set; }

        private readonly List<AppUserClaim> _claims = new List<AppUserClaim>();
        private readonly List<AppUserLogin> _logins = new List<AppUserLogin>();
        private readonly List<AppUserToken> _tokens = new List<AppUserToken>();
        public virtual IReadOnlyList<AppUserClaim> Claims => _claims.ToList();
        public virtual IReadOnlyList<AppUserLogin> Logins => _logins.ToList();
        public virtual IReadOnlyList<AppUserToken> Tokens => _tokens.ToList();

        protected AppUser()
        {
            UserRoles = new AppUserRoleCollection();
        }
        public AppUser(Guid UserId)
            : this()
        {
            this.Id = UserId;
        }

        public AppUser(UserName userName, FullName name, UserEmail email, List<Guid> roles, Civility civility)
            : this()
        {
            this.UserName = userName.Value;
            this.FullName = name;
            this.Email = email.Value;
            this.NormalizedEmail = email.Value;
            this.Civility = civility;
            DeleteInfo = DeleteInfo.Create().Value;
            EditRoles(roles);
        }
        internal void EditPersonalInfo(FullName fullName, Civility civility)
        {
            this.FullName = fullName;
            this.Civility = civility;
        }
        internal void MarkAsDeleted(DeleteInfo deleteInfo)
        {
            DeleteInfo = deleteInfo;
        }

        public void EditRoles(List<Guid> roles)
        {
            UserRoles.Value.Clear();
            var appRoles = roles.Select(x => new AppUserRole(x, this.Id)).ToList();
            UserRoles = AppUserRoleCollection.Create(appRoles).Value;
        }
        public void AssignRole(AppUserRole appUserRole)
        {
            UserRoles.Value.Add(appUserRole);
        }
        public void RemoveRole(AppUserRole appUserRole)
        {
            UserRoles.Value.RemoveAll(x=>x.RoleId == appUserRole.RoleId);
        }
    }
}
