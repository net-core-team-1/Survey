using Identity.Api.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Identity.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("Users", DatabaseSchema.IdentitySchema);
            builder.HasOne(a => a.Civility);
            builder.OwnsOne(a => a.FullName, a =>
            {
                a.Property(aa => aa.FirstName).HasColumnName("FirstName").HasMaxLength(50);
                a.Property(aa => aa.LastName).HasColumnName("LastName").HasMaxLength(50);
            });

            builder.HasMany(a => a.UserRoles)
                .WithOne(a=> a.User);

            builder.HasMany(a => a.Claims)
                .WithOne();

            builder.HasMany(a => a.Tokens)
                .WithOne();

            builder.HasMany(a => a.Logins)
                .WithOne();
        }
    }
}
