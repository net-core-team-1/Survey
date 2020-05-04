using CSharpFunctionalExtensions;
using Identity.Api.Identity.Domain.Civilities;
using Identity.Api.Identity.Domain.Roles;
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

        private readonly List<AppUserRole> _userRoles = new List<AppUserRole>();
        private readonly List<AppUserClaim> _claims = new List<AppUserClaim>();
        private readonly List<AppUserLogin> _logins = new List<AppUserLogin>();
        private readonly List<AppUserToken> _tokens = new List<AppUserToken>();

        public virtual IReadOnlyList<AppUserRole> UserRoles => _userRoles.ToList();
        public virtual IReadOnlyList<AppUserClaim> Claims => _claims.ToList();
        public virtual IReadOnlyList<AppUserLogin> Logins => _logins.ToList();
        public virtual IReadOnlyList<AppUserToken> Tokens => _tokens.ToList();

        protected AppUser()
        {

        }
        public AppUser(Guid UserId)
        {
            this.Id = UserId;
        }

        internal void EditPersonalInfo(FullName fullName, Civility civility)
        {
            this.FullName = fullName;
            this.Civility = civility;
        }

        public AppUser(UserName userName, FullName name, UserEmail email, AppUserRoleCollection roles, Civility civility)
            : this()
        {
            this.UserName = userName.Value;
            this.FullName = name;
            this.Email = email.Value;
            this.Civility = civility;
            DeleteInfo = DeleteInfo.Create().Value;
            EditRoles(roles.Value.Select(x => x.RoleId).ToList());
        }

        internal void MarkAsDeleted(DeleteInfo deleteInfo)
        {
            DeleteInfo = deleteInfo;
        }

        public void EditRoles(List<Guid> roles)
        {
            _userRoles.Clear();
            _userRoles.AddRange(roles.Select(x => new AppUserRole(x, this.Id)));
            //var rolesToAdd = roles
            //    .Where(r => _userRoles.Where(ur => ur.RoleId == r).Count() == 0)
            //    .Select(x => new AppUserRole(x, this.Id))
            //    .ToList();

            //var rolesToDelete = _userRoles
            // .Where(r => roles.Where(ur => ur == r.RoleId).Count() == 0)
            // .Select(x => x.RoleId).ToList();

            //_userRoles.AddRange(rolesToAdd);
            //_userRoles.RemoveAll(x => rolesToDelete.Contains(x.RoleId));
        }
    }
}
