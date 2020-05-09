using Identity.Api.Identity.Domain.RoleFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Data.Mapping
{
    public class RoleFeaturesMapping : IEntityTypeConfiguration<AppRoleFeatures>
    {
        public void Configure(EntityTypeBuilder<AppRoleFeatures> builder)
        {
            builder.ToTable("RoleFeatures", DatabaseSchema.IdentitySchema);
            builder.HasKey(a => a.Id);
            builder.Property(a => a.AssignedOn).HasColumnName("AssignedOn").IsRequired(true);
            builder.Property(a => a.AssignedBy).HasColumnName("AssignedBy").IsRequired(true);

            builder.HasOne(a => a.Role)
                .WithMany(a => a.Features)
                .HasForeignKey(a => a.RoleId);

            builder.HasOne(a => a.Feature)
            .WithMany(a => a.Roles)
            .HasForeignKey(a => a.FeatureId);
        }
    }
}
