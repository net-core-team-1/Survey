using System.Threading.Tasks;

namespace Survey.Common.CQRS.ServiceBus.RabbitMQ
{
    public interface IExchangeInitializer
    {
        Task Initialize();
    }
}
