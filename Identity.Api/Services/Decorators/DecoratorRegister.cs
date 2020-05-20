using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Decorators
{
    public class DecoratorRegister<TCommand, THandler>
        where TCommand : ICommand
        where THandler : ICommandHandler<TCommand>
    {
        public static void Register()
        {

        }
    }
}
