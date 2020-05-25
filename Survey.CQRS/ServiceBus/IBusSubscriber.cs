using Survey.CQRS.Commands;
using Survey.CQRS.Events;

namespace Survey.CQRS.ServiceBus
{
    public interface IBusSubscriber
    {
        void SubscribeCommand<TCommand>()
            where TCommand : ICommand
            ;

        void SubscribeEvent<TEvent>()
            where TEvent : IEvent;
    }
}
