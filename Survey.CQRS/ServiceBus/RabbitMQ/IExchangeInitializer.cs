using System.Threading.Tasks;

namespace Survey.CQRS.ServiceBus.RabbitMQ
{
    public interface IExchangeInitializer
    {
        Task Initialize();
    }
}
