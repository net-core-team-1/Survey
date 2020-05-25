using Survey.Common.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Outbox.Messages
{
    public class InboxMessage : IIdentifiable<string>
    {
        public string Id { get; set; }
        public DateTime ProcessedAt { get; set; }
    }
}
