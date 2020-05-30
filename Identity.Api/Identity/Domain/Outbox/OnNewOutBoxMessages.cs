using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Outbox
{
    public class OnNewOutBoxMessages
    {
        public delegate void OnNewOutboxMessages(IEnumerable<long> messageIds);
    }
}
