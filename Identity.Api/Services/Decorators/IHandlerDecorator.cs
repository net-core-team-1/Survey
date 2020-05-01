using Survey.Common.CQRS.Events;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Decorators
{
    public interface IHandlerDecorator<T> : ICommandHandler<T>
         where T : ICommand
    {
    }
}
