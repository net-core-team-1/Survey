using Common.Types.Types.ServiceBus;
using CSharpFunctionalExtensions;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Common.Messages
{
    public class PublishCommandSender : ICommandSender
    {
        private readonly IBusPublisher _busPublisher;
        public PublishCommandSender(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }
        public Result Send(ICommand command)
        {
            _busPublisher.SendAsync(command);
            return Result.Ok<ICommand>(command);
        }
    }
}
