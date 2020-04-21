using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Transverse.Domain.Users;

namespace Survey.Transverse.Infrastracture.Data.Mapping
{
    internal class UserPermissionMap : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.ToTable("USER_PERMISSIONS", schema: DbSchemaNames.Identity);

            builder.HasKey(a => new { a.PermissionId, a.UserId });

            builder.Property(a => a.Timestamp).IsRowVersion();


            builder.Property(a => a.AssociatedOn).IsRequired();

            builder.HasOne(a=>a.User)
                    .WithMany(a=>a.UserPermissions)
                    .HasForeignKey(a=>a.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Permission)
                  .WithMany()
                  .HasForeignKey(a => a.PermissionId)
                  .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
