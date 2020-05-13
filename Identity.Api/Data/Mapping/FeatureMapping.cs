using Identity.Api.Identity.Domain.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Data.Mapping
{
    public class FeatureMapping : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.ToTable("Features", schema: DatabaseSchema.IdentitySchema);
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Timestamp).IsRowVersion();

            builder.OwnsOne(a => a.FeatureInfo, a =>
            {
                a.Property(aa => aa.Label).HasColumnName("Label").HasMaxLength(50);
                a.Property(aa => aa.Controller).HasColumnName("Controller").HasMaxLength(50).IsRequired();
                a.Property(aa => aa.ControllerActionName).HasColumnName("ControllerActionName").IsRequired(false);
                a.Property(aa => aa.Description).HasColumnName("Description").HasMaxLength(500);
                a.Property(aa => aa.Action).HasColumnName("Action").HasMaxLength(50).IsRequired();
            });

            builder.OwnsOne(a => a.CreateInfo, a =>
            {

                a.Property(aa => aa.CreatedOn).HasColumnName("CreatedOn").HasDefaultValue(DateTime.Now).IsRequired(true);
                a.Property(aa => aa.CreatedBy).HasColumnName("CreatedBy").HasDefaultValue(null).IsRequired(false);
            });

            builder.OwnsOne(a => a.DisabeleInfo, a =>
            {
                a.Property(aa => aa.Disabled).HasColumnName("Disabled").HasDefaultValue(false).IsRequired(false);
                a.Property(aa => aa.DisabledBy).HasColumnName("DisabledBy").HasDefaultValue(null).IsRequired(false);
                a.Property(aa => aa.DisabledOn).HasColumnName("DisabledOn").HasDefaultValue(null).IsRequired(false);

            });

            builder.OwnsOne(a => a.DeleteInfo, a =>
            {
                a.Property(aa => aa.Deleted).HasColumnName("Deleted").HasDefaultValue(false).IsRequired(false);
                a.Property(aa => aa.DeleteReason).HasColumnName("DeletReason").HasDefaultValue(null).HasMaxLength(250).IsRequired(false);
                a.Property(aa => aa.DeletedBy).HasColumnName("DeletedBy").HasDefaultValue(null).IsRequired(false);
                a.Property(aa => aa.DeletedOn).HasColumnName("DeletedOn").HasDefaultValue(null).IsRequired(false);
            });

            builder.HasOne(a => a.Service)
                  .WithMany(a => a.Features)
                  .HasForeignKey(a => a.ServiceId)
                  .IsRequired();

            builder.HasMany(e => e.RoleFeatures)
             .WithOne(e => e.Feature)
             .HasForeignKey(rc => rc.FeatureId)
             .IsRequired();

        }
    }
}
