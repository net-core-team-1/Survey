using Common.Types.Types.Events;
using Identity.Api.Identity.Domain.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Data.Mapping
{
    public class OutboxMapping : IEntityTypeConfiguration<OutboxMessage>
    {
        public void Configure(EntityTypeBuilder<OutboxMessage> builder)
        {
            builder.ToTable("OutboxMessage", "outbox");
            builder.HasKey(a => a.Id);
            builder
               .Property(e => e.Id)
               .UseSqlServerIdentityColumn();

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            };

            builder
               .Property(e => e.Event)
               // using json instead of jsonb, as Newtonsoft.Json expects the $type property to be the first, but jsonb might reorder properties
               .HasColumnType("nvarchar(Max)")
               // Npgsql supports JSON out of the box, but doesn't handle hierarchies, so just using Newtonsoft to avoid more work 
               .HasConversion(
                   e => JsonConvert.SerializeObject(e, settings).ToString(),
                   e => JsonConvert.DeserializeObject<IEvent>(e, settings));

        }
    }
}
