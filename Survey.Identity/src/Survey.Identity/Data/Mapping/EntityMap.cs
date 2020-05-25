using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Identity.Domain.Entities;
using System;

namespace Survey.Identity.Data.Mapping
{
    internal class EntityMap : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)

        {
            builder.ToTable("ENTITIES", schema: DbSchemaNames.Identity);
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Timestamp).IsRowVersion();

            builder.OwnsOne(a => a.NameDesciption, a =>
            {

                a.Property(aa => aa.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
                a.Property(aa => aa.Description).HasColumnName("Description").HasMaxLength(255).IsRequired();
            });

            builder.OwnsOne(a => a.FuncCode, a =>
            {
                a.Property(aa => aa.Code).HasColumnName("Code").HasMaxLength(6).IsRequired();
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


            builder.HasOne<EntityLevel>(a => a.EntityLevel)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Entity>(a => a.ParentEntity)
                   .WithMany()
                   .HasForeignKey(a => a.ParentId)
                   .OnDelete(DeleteBehavior.Restrict);

        }


    }
}
