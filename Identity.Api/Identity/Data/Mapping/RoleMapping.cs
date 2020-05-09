using Identity.Api.Identity.Domain.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Identity.Data.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("Roles", DatabaseSchema.IdentitySchema);
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.OwnsOne(a => a.CreateInfo, a =>
            {

                a.Property(aa => aa.CreatedOn).HasColumnName("CreatedOn").HasDefaultValue(DateTime.Now).IsRequired(true);
                a.Property(aa => aa.CreatedBy).HasColumnName("CreatedBy").HasDefaultValue(null).IsRequired(false);
            });
            builder.OwnsOne(a => a.DisableInfo, a =>
            {
                a.Property(aa => aa.Disabled).HasColumnName("Disabled").HasDefaultValue(false).IsRequired(false);
                a.Property(aa => aa.DisabledBy).HasColumnName("DisabledBy").HasDefaultValue(null).IsRequired(false);
                a.Property(aa => aa.DisabledOn).HasColumnName("DisabledOn").HasDefaultValue(null).IsRequired(false);

            });
            builder.OwnsOne(a => a.DeleteInfo, a =>
            {
                a.Property(aa => aa.Deleted).HasColumnName("Deleted").HasColumnName("Deleted").HasDefaultValue(false);
                a.Property(aa => aa.DeletedBy).HasColumnName("DeletedBy").HasDefaultValue(null);
                a.Property(aa => aa.DeleteReason).HasColumnName("DeleteReason").HasDefaultValue(null).HasMaxLength(50);
                a.Property(aa => aa.DeletedOn).HasColumnName("DeletedOn").HasDefaultValue(null);
            });

            builder.HasMany(e => e.RoleClaims)
                .WithOne(e => e.Role)
                .HasForeignKey(rc => rc.RoleId)
                .IsRequired();

            builder.HasMany(e => e.Features)
                  .WithOne(e => e.Role)
                  .HasForeignKey(rc => rc.RoleId)
                  .IsRequired();
        }
    }
}
