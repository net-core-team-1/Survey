using Identity.Api.Data.Mapping;
using Identity.Api.Identity.Domain.AppServices;
using Identity.Api.Identity.Domain.AppUserRoles;
using Identity.Api.Identity.Domain.Civilities;
using Identity.Api.Identity.Domain.Features;
using Identity.Api.Identity.Domain.RoleFeature;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Structures;
using Identity.Api.Identity.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Api.Data
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
            builder.ApplyConfiguration(new AppServiceMapping());
            builder.ApplyConfiguration(new UserMapping());
            builder.ApplyConfiguration(new FeatureMapping());
            builder.ApplyConfiguration(new RoleMapping());
            builder.ApplyConfiguration(new RoleFeaturesMapping());
            builder.ApplyConfiguration(new CivilityMapping());
            builder.ApplyConfiguration(new UserRolesMapping());
            builder.ApplyConfiguration(new UserClaimMapping());
            builder.ApplyConfiguration(new RoleClaimMapping());
            builder.ApplyConfiguration(new UserTokenMapping());
            builder.ApplyConfiguration(new UserLoginMapping());
            builder.ApplyConfiguration(new AppServiceMapping());
            builder.ApplyConfiguration(new StructureMapping());
            builder.ApplyConfiguration(new StructureUsersMapping());

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            foreach (var relationship in builder.Model.GetEntityTypes().Where(e => e.IsOwned()).SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }
        }

        public DbSet<Civility> Civilities { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<AppRoleFeatures> AppRoleFeatures { get; set; }
        public DbSet<AppService> AppServices { get; set; }
        public DbSet<Structure> Structures { get; set; }
        public DbSet<StructureUsers> StructureUsers { get; set; }
    }

}
