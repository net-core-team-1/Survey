using Common.Types.Types.Events;
using Survey.Common.Types;
using System.Threading.Tasks;

namespace Common.Types.Types.ServiceBus
{
    public interface IBusPublisher
    {
        void SendAsync<TCommand>(TCommand command) where TCommand : ICommand;

        void PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
