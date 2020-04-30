using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Identity.Domain.Users;
using Survey.Transverse.Domain.Users;

namespace Survey.Identity.Data.Mapping
{
    internal class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {

            builder.ToTable("USERS_ROLES", schema: DbSchemaNames.Identity);
            builder.Property(a => a.Timestamp).IsRowVersion();


            builder.Property(a => a.AssociatedOn).IsRequired();

            builder.HasOne(a=>a.User)
                    .WithMany(a=>a.UserRoles)
                    .HasForeignKey(a=>a.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Role)
                  .WithMany()
                  .HasForeignKey(a => a.RoleId)
                  .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
