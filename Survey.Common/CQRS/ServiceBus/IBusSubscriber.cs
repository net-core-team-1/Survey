using Common.Types.Types.Events;
using Survey.Common.Types;

namespace Common.Types.Types.ServiceBus
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
