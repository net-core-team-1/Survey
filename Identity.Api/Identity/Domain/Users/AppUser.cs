using Common.Types.Types.Events;
using CSharpFunctionalExtensions;
using Identity.Api.Identity.Domain.AppServices;
using Identity.Api.Identity.Domain.AppUserRoles;
using Identity.Api.Identity.Domain.Civilities;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Structures;
using Identity.Api.Identity.Domain.Users.Events;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Identity.Api.Identity.Domain.Users
{
    public class AppUser : IdentityUser<Guid>, IDomainEntity
    {
        public virtual FullName FullName { get; protected set; }
        public virtual Civility Civility { get; protected set; }
        public DateTime? LastConnexionOn { get; private set; }

        public virtual int CivilityId { get; protected set; }
        public virtual DeleteInfo DeleteInfo { get; protected set; }
        public virtual AppUserRoleCollection UserRoles { get; protected set; }
        public virtual StructureUsersCollection StructureUsers { get; protected set; }

        private readonly List<AppUserClaim> _claims = new List<AppUserClaim>();
        private readonly List<AppUserLogin> _logins = new List<AppUserLogin>();
        private readonly List<AppUserToken> _tokens = new List<AppUserToken>();
        public virtual IReadOnlyList<AppUserClaim> Claims => _claims.ToList();
        public virtual IReadOnlyList<AppUserLogin> Logins => _logins.ToList();
        public virtual IReadOnlyList<AppUserToken> Tokens => _tokens.ToList();

        public List<IEvent> Events { get; set; }

        public AppUser()
        {
            Events = new List<IEvent>();
            this.Id = Guid.NewGuid();
            UserRoles = new AppUserRoleCollection();
            StructureUsers = new StructureUsersCollection();
        }
        public AppUser(Guid UserId)
            : this()
        {
            this.Id = UserId;
        }

        public AppUser(UserName userName, FullName name, UserEmail email, List<Guid> roles, Civility civility, Structure structure)
            : this()
        {
            this.UserName = userName.Value;
            this.FullName = name;
            this.Email = email.Value;
            this.NormalizedEmail = email.Value;
            this.CivilityId = civility.Id;
            DeleteInfo = DeleteInfo.Create().Value;
            EditRoles(roles);
            AssignToStructure(structure);
            Events.Add(new UserRegistredEvent(userName.Value, name.FirstName, name.LastName
                , email.Value, civility.Id, structure.Id, roles));
        }

        internal void SetLastConnexionDate()
        {
            this.LastConnexionOn = DateTime.Now;
        }

        internal void EditPersonalInfo(FullName fullName, int civilityId)
        {
            this.FullName = fullName;
            this.CivilityId = civilityId;
            Events.Add(new UserEditedEvent(this.Id, fullName.FirstName,
                fullName.LastName, civilityId));
        }

        internal void MarkAsDeleted(DeleteInfo deleteInfo)
        {
            DeleteInfo = deleteInfo;
            Events.Add(new UserUnregistredEvent(this.Id, deleteInfo.DeleteReason,
                deleteInfo.DeletedBy.Value, deleteInfo.DeletedOn.Value));
        }

        public void EditRoles(List<Guid> roles)
        {
            UserRoles.Value.Clear();
            var appRoles = roles.Select(x => new AppUserRole(x, this.Id)).ToList();
            UserRoles = AppUserRoleCollection.Create(appRoles).Value;
            Events.Add(new UserRolesEditedEvent(this.Id, roles));
        }
        public void AssignRole(AppUserRole appUserRole)
        {
            UserRoles.Value.Add(appUserRole);
            Events.Add(new UserRoleRegistredEvent(appUserRole.UserId, appUserRole.RoleId));
        }
        public void RemoveRole(AppUserRole appUserRole)
        {
            UserRoles.Value.RemoveAll(x => x.RoleId == appUserRole.RoleId);
            Events.Add(new UserRoleUnregistredEvent(appUserRole.UserId, appUserRole.RoleId));
        }
        internal void AssignToStructure(Structure structure)
        {
            StructureUsers.Add(new StructureUsers(structure.Id, this.Id));
        }

    }
}
