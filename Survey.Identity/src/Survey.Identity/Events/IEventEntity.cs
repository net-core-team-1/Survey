using Survey.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Events
{
    public interface IEventEntity
    {
        public List<IEvent> Events { get; set; }
        public void ClearEvent();
        public void Rise(IEvent @event);

    }
}
