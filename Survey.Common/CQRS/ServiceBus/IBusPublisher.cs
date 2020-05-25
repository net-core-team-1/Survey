using Common.Types.Types.Events;
using Survey.Common.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Types.Types.ServiceBus
{
    public interface IBusPublisher
    {
        void SendAsync<TCommand>(TCommand command) where TCommand : ICommand;

        //void PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
        Task PublishAsync<T>(T message, string messageId = null, string correlationId = null, string spanContext = null,
            object messageContext = null, IDictionary<string, object> headers = null) where T : class;
    }
}
