using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Identity.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Data.Mapping
{
    public class MicroServiceMap : IEntityTypeConfiguration<MicroService>
    {
        public void Configure(EntityTypeBuilder<MicroService> builder)
        {
            builder.ToTable("MICRO_SERVICES", schema: DbSchemaNames.Identity);
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Timestamp).IsRowVersion();

            builder.Property(a => a.Name).HasMaxLength(100);
            builder.Property(a => a.Description).HasMaxLength(255);
            builder.Property(a => a.Timestamp).IsRowVersion();


            builder.OwnsOne(a => a.CreateInfo, a =>
            {

                a.Property(aa => aa.CreatedOn).HasColumnName("CreatedOn").HasDefaultValue(DateTime.Now).IsRequired(true);
                a.Property(aa => aa.CreatedBy).HasColumnName("CreatedBy").HasDefaultValue(null).IsRequired(false);
            });
            builder.OwnsOne(a => a.DeleteInfo, a =>
            {

                a.Ignore(aa => aa.Deleted);
                a.Property(aa => aa.DeleteReason).HasColumnName("DeletReason").HasDefaultValue(null).HasMaxLength(250).IsRequired(false);
                a.Property(aa => aa.DeletedBy).HasColumnName("DeletedBy").HasDefaultValue(null).IsRequired(false);
                a.Property(aa => aa.DeletedOn).HasColumnName("DeletedOn").HasDefaultValue(null).IsRequired(false);
            });

        }
    }
}
