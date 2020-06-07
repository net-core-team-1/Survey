using Survey.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Survey.BaseTypes;

namespace Survey.BaseTypes
{
    public abstract class AggregateRoot
    {
        private readonly List<IEvent> _changes = new List<IEvent>();

        public abstract Guid Id { get; }
        public int Version { get; internal set; }

        public IEnumerable<IEvent> GetUncommittedChanges()
        {
            return _changes;
        }

        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

     

      

     
    }

}
