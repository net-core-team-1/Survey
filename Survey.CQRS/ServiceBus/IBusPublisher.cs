using Survey.CQRS.Commands;
using Survey.CQRS.Events;

namespace Survey.CQRS.ServiceBus
{
    public interface IBusPublisher
    {
        void SendAsync<TCommand>(TCommand command) where TCommand : ICommand;

        void PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
