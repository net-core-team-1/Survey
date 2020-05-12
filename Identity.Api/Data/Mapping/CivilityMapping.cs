using Identity.Api.Identity.Domain.Civilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Data.Mapping
{
    public class CivilityMapping : IEntityTypeConfiguration<Civility>
    {
        public void Configure(EntityTypeBuilder<Civility> builder)
        {
            builder.ToTable("Civility", DatabaseSchema.IdentitySchema);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(10).Metadata.AfterSaveBehavior = Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore;
            builder.Property(x => x.Description).HasMaxLength(25).Metadata.AfterSaveBehavior = Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore;
        }
    }
}
