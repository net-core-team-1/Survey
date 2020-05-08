using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Identity.Domain.Identity;

namespace Survey.Identity.Data.Mapping
{
    internal sealed class RefreshTokenMap : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("REFRESH_TOKENS",schema:DbSchemaNames.Identity);
            builder.HasKey(a => a.Id);


            builder.Property(a => a.Token).HasMaxLength(250);
            builder.Property(a => a.Timestamp).IsRowVersion();
            builder.Property(a => a.JwtId).HasMaxLength(50);

            builder.HasOne(a => a.User).WithMany().IsRequired()
                 .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
