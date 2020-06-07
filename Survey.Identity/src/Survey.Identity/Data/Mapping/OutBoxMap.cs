using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Survey.CQRS.Events;
using Survey.Identity.Data.OutBox;
using Survey.Identity.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Data.Mapping
{
    public class OutBoxMap : IEntityTypeConfiguration<OutboxMessage>
    {
        public void Configure(EntityTypeBuilder<OutboxMessage> builder)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            };
            builder.ToTable("OUTBOX_MESSAGES");
            builder.HasKey(e => e.Id);
            builder.Property(a => a.Id).HasDefaultValue(Guid.NewGuid());
            builder.Property(a => a.CreatedAt).IsRequired();
            builder.Property(a => a.ProcessedAt).IsRequired(false);
            builder.Property(e => e.Event)
                .HasColumnType("nvarchar(max)")
                .HasConversion(
                    e => JsonConvert.SerializeObject(e, settings),
                    e => JsonConvert.DeserializeObject<IEvent>(e, settings)
                    );
        }
    }
}
