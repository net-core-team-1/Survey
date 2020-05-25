using Common.Types.Types.Events;
using Common.Types.Types.ServiceBus;
using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Services.Decorators;
using Survey.Common.CQRS.Events;
using Survey.Common.Types;
using Survey.Outbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.HandlersDecorators
{
    public class PublishEventWhenHandlingDecorator<TCommand>
            : IHandlerDecorator<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _decorated;
        private readonly IRejectedEvent<TCommand> _rejectedEvent;
        private readonly IAcceptedEvent<TCommand> _acceptedEvent;
        private readonly IBusPublisher _bus;
        private readonly IMessageOutbox _outbox;
        public PublishEventWhenHandlingDecorator(ICommandHandler<TCommand> decorated,
                                                 IRejectedEvent<TCommand> rejectedEvent,
                                                 IAcceptedEvent<TCommand> acceptedEvent,
                                                 IBusPublisher bus,
                                                 IMessageOutbox outbox)
        {
            _decorated = decorated;
            _bus = bus;
            _rejectedEvent = rejectedEvent;
            _acceptedEvent = acceptedEvent;
            _outbox = outbox;
        }
        public async Task<Result> Handle(TCommand command)
        {
            try
            {
                await _decorated.Handle(command);
                if (_outbox.Enabled)
                {
                    await _outbox.SendAsync(GetEvent(command));
                    //return;
                }
                //PublishAcceptedEvent(command);
                return await Task.FromResult(Result.Ok());
            }
            catch (IdentityException ex)
            {
                PublishRejectedEvent(command, ex.Message, ex.Code);
                throw ex;
            }
            catch (Exception ex)
            {
                PublishRejectedEvent(command, ex.Message, command.GetType().Name.ToString());
                throw ex;
            }
        }

        private void PublishRejectedEvent(TCommand command, string reason, string code)
        {
            _bus.PublishAsync<IRejectedEvent<TCommand>>(_rejectedEvent.CreateFrom(reason, code, command));
        }

        private void PublishAcceptedEvent(TCommand command)
        {
            _bus.PublishAsync<IAcceptedEvent<TCommand>>(_acceptedEvent.CreateFrom(command));
        }
        private IAcceptedEvent<TCommand> GetEvent(TCommand command)
        {
            return _acceptedEvent.CreateFrom(command);
        }

    }
}
