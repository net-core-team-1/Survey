using Identity.Api.Identity.Domain.RoleFeature;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Data.Mapping
{
    public class RoleFeaturesMapping : IEntityTypeConfiguration<AppRoleFeatures>
    {
        public void Configure(EntityTypeBuilder<AppRoleFeatures> builder)
        {
            builder.ToTable("RoleFeatures", DatabaseSchema.IdentitySchema);
            builder.HasKey(k => new { k.RoleId, k.FeatureId });
            builder.OwnsOne(a => a.CreateInfo, a =>
            {
                a.Property(aa => aa.CreatedOn).HasColumnName("CreatedOn").HasDefaultValue(DateTime.Now).IsRequired(true);
                a.Property(aa => aa.CreatedBy).HasColumnName("CreatedBy").HasDefaultValue(null).IsRequired(false);
            });
            //builder.Property(a => a.CreatedOn).HasColumnName("CreatedOn").HasDefaultValue(DateTime.Now).IsRequired(true);
            //builder.Property(a => a.CreatedBy).HasColumnName("CreatedBy").HasDefaultValue(null).IsRequired(false);

            builder.HasOne(a => a.Role)
                .WithMany(a => a.RoleFeatures)
                .HasForeignKey(a => a.RoleId);


            builder.HasOne(a => a.Feature)
              .WithMany(a => a.RoleFeatures)
              .HasForeignKey(a => a.FeatureId);
             
        }
    }
}
