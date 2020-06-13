using Identity.Api.Identity.Domain.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Data.Mapping
{
    internal sealed class RefreshTokenMapping : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("REFRESH_TOKENS", schema: DatabaseSchema.IdentitySchema);
            builder.HasKey(a => a.Id);

            builder.Property(a => a.UserId).IsRequired();
            builder.Property(a => a.Token).HasMaxLength(1000);
            builder.Property(a => a.Timestamp).IsRowVersion();
            builder.Property(a => a.JwtId).HasMaxLength(50);

            builder.HasOne(a => a.User).WithMany().IsRequired()
                 .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
