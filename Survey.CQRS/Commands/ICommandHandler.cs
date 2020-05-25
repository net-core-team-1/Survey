using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survey.CQRS.Commands
{
    public interface ICommandHandler<TCommand>
       where TCommand : ICommand
    {
        Task<Result> Handle(TCommand command);
    }
}
