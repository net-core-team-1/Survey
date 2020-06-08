using CSharpFunctionalExtensions;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Common.Messages
{
    public class DispatchCommandSender : ICommandSender
    {
        private readonly Dispatcher _dispatcher;
        public DispatchCommandSender(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        public Result Send(ICommand command)
        {
            return _dispatcher.Dispatch(command);
        }
    }
}
