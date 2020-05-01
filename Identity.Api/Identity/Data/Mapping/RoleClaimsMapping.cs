using Identity.Api.Identity.Domain.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Identity.Data.Mapping
{
    public class RoleClaimMapping : IEntityTypeConfiguration<AppRoleClaim>
    {
        public void Configure(EntityTypeBuilder<AppRoleClaim> builder)
        {
            builder.ToTable("RoleClaims", DatabaseSchema.IdentitySchema);
            builder.HasOne(a => a.Role)
                .WithMany(a => a.RoleClaims)
                .HasForeignKey(a => a.RoleId);
        }
    }
}
