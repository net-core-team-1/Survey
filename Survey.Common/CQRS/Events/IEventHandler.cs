using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Types.Types.Events
{
    public interface IEventHandler<TEvent>
         where TEvent : IEvent
    {
        Task Handle(TEvent @event);
    }
}
