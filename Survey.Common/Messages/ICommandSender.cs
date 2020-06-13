using CSharpFunctionalExtensions;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Common.Messages
{
    public interface ICommandSender
    {
        Result Send(ICommand command);

        Task<Result> SendAsync(ICommand command);
    }
}
