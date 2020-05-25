using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Outbox.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Outbox.EntityFramwork.Mapping
{
    public class InboxMessageMapping : IEntityTypeConfiguration<InboxMessage>
    {
        public void Configure(EntityTypeBuilder<InboxMessage> builder)
        {
            builder.ToTable("InboxMessage", schema: "outbox");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.ProcessedAt).HasColumnName("ProcessedAt");
           
        }
    }
}
