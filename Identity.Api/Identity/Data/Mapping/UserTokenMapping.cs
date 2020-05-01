using Identity.Api.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Identity.Data.Mapping
{
    public class UserTokenMapping : IEntityTypeConfiguration<AppUserToken>
    {
        public void Configure(EntityTypeBuilder<AppUserToken> builder)
        {
            builder.ToTable("UserTokens", DatabaseSchema.IdentitySchema);
            builder.HasOne(a => a.User)
                .WithMany(a => a.Tokens)
                .HasForeignKey(a => a.UserId);
        }
    }
}
