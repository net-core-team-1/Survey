using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Outbox.Messages
{
    public class OutboxMessage
    {
        public virtual string Id { get; set; }
        public virtual string OriginatedMessageId { get; set; }
        public virtual string CorrelationId { get; set; }
        public virtual string SpanContext { get; set; }
        public virtual string MessageType { get; set; }
        public virtual string MessageContextType { get; set; }
        //public virtual Dictionary<string, byte[]> Headers { get; set; } = new Dictionary<string, byte[]>();
        public virtual byte[] Message { get; set; }
        public virtual byte[] MessageContext { get; set; }
        public virtual string SerializedMessage { get; set; }
        public virtual string SerializedMessageContext { get; set; }
        public virtual DateTime SentAt { get; set; }
        public virtual DateTime? ProcessedAt { get; set; }
    }
}
