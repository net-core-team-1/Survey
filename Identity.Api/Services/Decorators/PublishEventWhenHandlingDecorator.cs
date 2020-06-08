using Common.Types.Types.Events;
using Common.Types.Types.ServiceBus;
using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Services.Decorators;
using Survey.Common.CQRS.Events;
using Survey.Common.Types;
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
        private readonly IBusPublisher _bus;
        public PublishEventWhenHandlingDecorator(ICommandHandler<TCommand> decorated,
                                                        IRejectedEvent<TCommand> rejectedEvent,
                                                        IBusPublisher bus)
        {
            _decorated = decorated;
            _bus = bus;
            _rejectedEvent = rejectedEvent;
        }
        public async Task<Result> Handle(TCommand command)
        {
            try
            {
                await _decorated.Handle(command);
                return await Task.FromResult(Result.Ok());
            }
            catch (IdentityException ex)
            {
                PublishRejectedEvent(command, ex.Message, ex.Code);
                return await Task<Result>.FromResult(Result.Failure<TCommand>(ex.Message));
            }
            catch (Exception ex)
            {
                PublishRejectedEvent(command, ex.Message, command.GetType().Name.ToString());
                return await Task<Result>.FromResult(Result.Failure<TCommand>(ex.Message));
            }
        }

        private void PublishRejectedEvent(TCommand command, string reason, string code)
        {
            _bus.PublishAsync<IRejectedEvent<TCommand>>(_rejectedEvent.CreateFrom(reason, code, command));
        }
    }
}
