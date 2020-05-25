using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Outbox.Messages;
using Survey.Outbox.Processors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Outbox.EntityFramwork.Mapping
{
    public class OutboxMessageMapping : IEntityTypeConfiguration<OutboxMessage>
    {
        public void Configure(EntityTypeBuilder<OutboxMessage> builder)
        {
            builder.ToTable("OutboxMessage", "outbox");
            builder.HasKey(a => a.Id);
          
        }
    }
}
