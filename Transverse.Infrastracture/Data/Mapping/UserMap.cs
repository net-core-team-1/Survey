using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Transverse.Domain.Users;
using System;

namespace Survey.Transverse.Infrastracture.Data.Mapping
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USERS", schema: DbSchemaNames.Identity);

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Timestamp).IsRowVersion();



            builder.OwnsOne(a => a.CreateInfo, a =>
            {

                a.Property(aa => aa.CreatedOn).HasColumnName("CreatedOn").HasDefaultValue(DateTime.Now).IsRequired(true);
                a.Property(aa => aa.CreatedBy).HasColumnName("CreatedBy").HasDefaultValue(null).IsRequired(false);
            });

            builder.OwnsOne(a => a.FullName, a =>
            {

                a.Property(aa => aa.FirstName).HasColumnName("FirstName").HasMaxLength(50);
                a.Property(aa => aa.LastName).HasColumnName("LastName").HasMaxLength(50);
            });
            builder.OwnsOne(a => a.Email, a =>
            {

                a.Property(aa => aa.EmailAdress).HasColumnName("Email").HasMaxLength(50).IsRequired();
            });
            builder.OwnsOne(a => a.Password, a =>
            {

                a.Property(aa => aa.PasswordHash).HasColumnName("PasswordHash").IsRequired(false);
                a.Property(aa => aa.PasswordSalt).HasColumnName("PasswordSalt").IsRequired(false);
            });



            builder.OwnsOne(a => a.DeleteInfo, a =>
            {

                a.Ignore(aa => aa.Deleted);
                a.Property(aa => aa.DeleteReason).HasColumnName("DeletReason").HasDefaultValue(null).HasMaxLength(250).IsRequired(false);
                a.Property(aa => aa.DeletedBy).HasColumnName("DeletedBy").HasDefaultValue(null).IsRequired(false);
                a.Property(aa => aa.DeletedOn).HasColumnName("DeletedOn").HasDefaultValue(null).IsRequired(false);
            });


            builder.HasMany<UserPermission>(a => a.UserPermissions)
                   .WithOne(a => a.User)
                   .HasForeignKey(a => a.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field); 
        }
    }
}
