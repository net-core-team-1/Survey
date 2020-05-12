using Identity.Api.Identity.Domain.AppUserRoles;
using Identity.Api.Identity.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Data.Mapping
{
    public class UserRolesMapping : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.ToTable("UserRoles", DatabaseSchema.IdentitySchema);
            builder.Property(x => x.Enabled)
                   .HasDefaultValue(true)
                   .IsRequired(true);

            builder.Property(x => x.AssociatedOn)
                   .HasDefaultValue(DateTime.UtcNow.ToUniversalTime())
                   .IsRequired(true);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.UserRoles)
                   .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Role)
                   .WithMany()
                   .HasForeignKey(x => x.RoleId);

        }
    }
}
