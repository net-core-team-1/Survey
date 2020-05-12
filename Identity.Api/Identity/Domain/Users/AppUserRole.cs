using CSharpFunctionalExtensions;
using Identity.Api.Identity.Domain.AppServices;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Users;
using Microsoft.AspNetCore.Identity;
using RabbitMQ.Client.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Identity.Api.Identity.Domain.AppUserRoles
{
    public class AppUserRole : IdentityUserRole<Guid>
    {
        public virtual AppRole Role { get; protected set; }
        public virtual AppUser User { get; protected set; }
        public virtual bool Enabled { get; protected set; }
        public virtual DateTime AssociatedOn { get; protected set; }

        public AppUserRole()
        {
        }
        public AppUserRole(Guid roleId, Guid userId)
           : this()
        {
            UserId = userId;
            RoleId = roleId;
            Enabled = true;
            AssociatedOn = DateTime.Now.ToUniversalTime();
        }
        public AppUserRole(AppRole role, AppUser user, AppService appService)
            : this(role.Id, user.Id)
        {
            Role = role;
            User = user;
        }
    }
}
