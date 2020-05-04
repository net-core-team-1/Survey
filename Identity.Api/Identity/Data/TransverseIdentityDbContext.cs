using Identity.Api.Identity.Data.Mapping;
using Identity.Api.Identity.Domain.Civilities;
using Identity.Api.Identity.Domain.Features;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Data
{
    public class TransverseIdentityDbContext :
        IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole,
        AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public TransverseIdentityDbContext(DbContextOptions<TransverseIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserMapping());
            builder.ApplyConfiguration(new RoleMapping());
            builder.ApplyConfiguration(new CivilityMapping());
            builder.ApplyConfiguration(new UserRolesMapping());
            builder.ApplyConfiguration(new UserClaimMapping());
            builder.ApplyConfiguration(new RoleClaimMapping());
            builder.ApplyConfiguration(new UserTokenMapping());
            builder.ApplyConfiguration(new UserLoginMapping());
            builder.ApplyConfiguration(new FeatureMapping());
        }

        public DbSet<Civility> Civilities { get; set; }
        public DbSet<Feature> Features { get; set; }
    }

}
