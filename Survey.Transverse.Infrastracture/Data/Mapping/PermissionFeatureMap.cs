﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Transverse.Domain.Permissions;

namespace Survey.Transverse.Infrastracture.Data.Mapping
{
    internal class PermissionFeatureMap : IEntityTypeConfiguration<PermissionFeature>
    {
        public void Configure(EntityTypeBuilder<PermissionFeature> builder)
        {
            builder.ToTable("PERMISSIONS_FEATURES", schema: DbSchemaNames.Identity);

            builder.HasKey(a => new { a.FeatureId, a.PermissionId });


            builder.Property(a => a.Timestamp).IsRowVersion();


            builder.HasOne(a => a.Permission)
                   .WithMany(a => a.PermissionFeatures)
                   .HasForeignKey(a => a.PermissionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Feature)
                  .WithMany()
                  .HasForeignKey(a => a.FeatureId)
                  .OnDelete(DeleteBehavior.Cascade);



        }
    }
}