using Identity.Api.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("Users", DatabaseSchema.IdentitySchema);
            builder.HasOne(a => a.Civility).WithMany();
            builder.OwnsOne(a => a.FullName, a =>
            {
                a.Property(aa => aa.FirstName).HasColumnName("FirstName").HasMaxLength(50);
                a.Property(aa => aa.LastName).HasColumnName("LastName").HasMaxLength(50);
            });

            builder.OwnsOne(a => a.DeleteInfo, a =>
             {
                 a.Property(aa => aa.Deleted).HasColumnName("Deleted").HasColumnName("Deleted").HasDefaultValue(false);
                 a.Property(aa => aa.DeletedBy).HasColumnName("DeletedBy").HasDefaultValue(null);
                 a.Property(aa => aa.DeleteReason).HasColumnName("DeleteReason").HasDefaultValue(null).HasMaxLength(50);
                 a.Property(aa => aa.DeletedOn).HasColumnName("DeletedOn").HasDefaultValue(null);
             });

            builder.HasMany(a => a.UserRoles)
                .WithOne(a => a.User)
                .HasForeignKey(a=>a.UserId);

            builder.HasMany(a => a.Claims)
                .WithOne();

            builder.HasMany(a => a.Tokens)
                .WithOne();

            builder.HasMany(a => a.Logins)
                .WithOne();
        }
    }
}
