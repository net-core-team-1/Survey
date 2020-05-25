using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Identity.Domain.Roles;

namespace Survey.Identity.Data.Mapping
{
    internal class RoleFeatureMap : IEntityTypeConfiguration<RoleFeature>
    {
        public void Configure(EntityTypeBuilder<RoleFeature> builder)
        {
            builder.ToTable("ROLES_FEATURES", schema: DbSchemaNames.Identity);

            builder.HasKey(a => new { a.FeatureId, a.RoleId });


            builder.Property(a => a.Timestamp).IsRowVersion();


            builder.HasOne(a => a.Role)
                   .WithMany(a => a.RoleFeatures)
                   .HasForeignKey(a => a.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Feature)
                  .WithMany()
                  .HasForeignKey(a => a.FeatureId)
                  .OnDelete(DeleteBehavior.Restrict);



        }
    }
}