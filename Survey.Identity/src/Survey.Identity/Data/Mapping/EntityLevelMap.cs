using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Identity.Domain.Entities;
using Survey.Identity.Domain.Features;
using System;

namespace Survey.Identity.Data.Mapping
{
    internal class EntityLevelMap : IEntityTypeConfiguration<EntityLevel>
    {
        public void Configure(EntityTypeBuilder<EntityLevel> builder)
        {
            builder.ToTable("ENTITIES_LEVELS", schema: DbSchemaNames.Identity);
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Timestamp).IsRowVersion();

            builder.OwnsOne(a => a.NameDesciption, a =>
            {

                a.Property(aa => aa.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
                a.Property(aa => aa.Description).HasColumnName("Description").HasMaxLength(255).IsRequired();
            });

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


            builder.HasOne(a => a.Parent)
                .WithMany()
                .HasForeignKey(a => a.ParentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            ;

        }


    }
}
