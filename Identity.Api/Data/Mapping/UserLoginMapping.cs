using Identity.Api.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Data.Mapping
{
    public class UserLoginMapping : IEntityTypeConfiguration<AppUserLogin>
    {
        public void Configure(EntityTypeBuilder<AppUserLogin> builder)
        {
            builder.ToTable("UserLogins", DatabaseSchema.IdentitySchema);
            builder.HasOne(a => a.User)
                .WithMany(a => a.Logins)
                .HasForeignKey(a => a.UserId);
        }
    }
}
