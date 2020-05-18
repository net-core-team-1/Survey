using Identity.Api.Identity.Domain.Structures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Data.Mapping
{
    public class StructureUsersMapping : IEntityTypeConfiguration<StructureUsers>
    {
        public void Configure(EntityTypeBuilder<StructureUsers> builder)
        {
            builder.ToTable("StructureUsers", DatabaseSchema.IdentitySchema);
            builder.HasKey(x => new { x.StructureId, x.UserId });

            builder.HasOne(x => x.Structure)
                   .WithMany(x => x.StructureUsers)
                   .HasForeignKey(x => x.StructureId);

            builder.HasOne(x => x.User)
                   .WithMany(x => x.StructureUsers)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
