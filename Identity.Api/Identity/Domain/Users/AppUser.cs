using CSharpFunctionalExtensions;
using Identity.Api.Identity.Domain.Civilities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Identity.Api.Identity.Domain.Users
{
    public class AppUser : IdentityUser<Guid>
    {
        public FullName FullName { get; protected set; }
        public Civility Civility { get; protected set; }
        public DeleteInfo DeleteInfo { get; protected set; }

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
            EditRoles(roles.Value);
        }

        internal void MarkAsDeleted(DeleteInfo deleteInfo)
        {
            DeleteInfo = deleteInfo;
        }

        public void EditRoles(List<AppUserRole> roles)
        {
            _userRoles.Clear();
            _userRoles.AddRange(roles);
        }
    }
}
