using CSharpFunctionalExtensions;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;


namespace Survey.Common.Messages
{
    public interface ICommandSender
    {
        Result Send(ICommand command);
    }
}
