using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Survey.Identity.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Identity.Domain.Users;
using Survey.Identity.Domain.Roles;
using System;
using Survey.Identity.Data.Mapping;
using Survey.Identity.Domain.Features;
using Survey.Identity.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Survey.Identity.Data
{
    public class SurveyIdentityContext: IdentityDbContext<User,Role,Guid, UserClaim, UserRole,UserLogin,RoleClaim,UserToken>
    {

        public SurveyIdentityContext(DbContextOptions<SurveyIdentityContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserClaim>().ToTable("USER_CLAIMS", schema: DbSchemaNames.Identity);
            builder.Entity<UserLogin>().ToTable("USER_LOGINS", schema: DbSchemaNames.Identity);
            builder.Entity<RoleClaim>().ToTable("ROLE_CLAIMS", schema: DbSchemaNames.Identity);
            builder.Entity<UserToken>().ToTable("USER_TOKENS", schema: DbSchemaNames.Identity);

            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new FeatureMap());
            builder.ApplyConfiguration(new RoleMap());
            builder.ApplyConfiguration(new UserRoleMap());
            builder.ApplyConfiguration(new RoleFeatureMap());
            builder.ApplyConfiguration(new RefreshTokenMap());
        }



        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    }
}
