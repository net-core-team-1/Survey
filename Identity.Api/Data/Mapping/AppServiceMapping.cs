﻿using Identity.Api.Identity.Domain.AppServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Data.Mapping
{
    public class AppServiceMapping : IEntityTypeConfiguration<AppService>
    {
        public void Configure(EntityTypeBuilder<AppService> builder)
        {
            builder.ToTable("AppServices", schema: DatabaseSchema.IdentitySchema);
            builder.HasKey(a => a.Id);

            builder.OwnsOne(a => a.ServiceInfo, a =>
            {
                a.Property(aa => aa.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
                a.Property(aa => aa.Description).HasColumnName("Description").HasMaxLength(250).IsRequired();
            });

            builder.OwnsOne(a => a.CreationInfo, a =>
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
                a.Property(aa => aa.Deleted).HasColumnName("Deleted").HasDefaultValue(false).IsRequired(false);
                a.Property(aa => aa.DeleteReason).HasColumnName("DeletReason").HasDefaultValue(null).HasMaxLength(250).IsRequired(false);
                a.Property(aa => aa.DeletedBy).HasColumnName("DeletedBy").HasDefaultValue(null).IsRequired(false);
                a.Property(aa => aa.DeletedOn).HasColumnName("DeletedOn").HasDefaultValue(null).IsRequired(false);
            });

            builder.HasMany(e => e.Roles)
               .WithOne(e => e.Service)
               .HasForeignKey(rc => rc.ServiceId)
               .IsRequired();

            builder.HasMany(e => e.Features)
              .WithOne(e => e.Service)
              .HasForeignKey(rc => rc.ServiceId)
              .IsRequired();
        }
    }
}