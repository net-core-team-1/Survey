using CSharpFunctionalExtensions;
using Identity.Api.Identity.Domain.RoleFeatures;
using Identity.Api.Identity.Domain.Roles;
using Microsoft.AspNetCore.Identity;
using RabbitMQ.Client.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Identity.Api.Identity.Domain.Users
{
    public class AppUserRole : IdentityUserRole<Guid>
    {
        public virtual AppRole Role { get; set; }
        public virtual AppUser User { get; set; }
        public virtual bool Enabled { get; set; }
        public virtual DateTime AssociatedOn { get; set; }
       
        public AppUserRole()
        {
        }
        public AppUserRole(AppRole role, AppUser user)
            : this()
        {
            Role = role;
            User = user;
            RoleId = role.Id;
            UserId = user.Id;
            Enabled = true;
            AssociatedOn = DateTime.Now.ToUniversalTime();
        }

        public AppUserRole(Guid roleId)
             : this()
        {
            Role = new AppRole(roleId);
            RoleId = roleId;
            Enabled = true;
            AssociatedOn = DateTime.Now.ToUniversalTime();
        }

        public AppUserRole(Guid roleId, Guid userId)
             : this()
        {
            UserId = userId;
            RoleId = roleId;
            Enabled = true;
            AssociatedOn = DateTime.Now.ToUniversalTime();
        }
    }
}
