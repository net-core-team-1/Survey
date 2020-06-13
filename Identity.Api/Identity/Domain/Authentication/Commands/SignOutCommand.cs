using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Authentication.Commands
{
    public sealed class SignOutCommand : ICommand
    {
        public Guid Id { get; }
        public SignOutCommand(Guid id)
        {
            Id = id;
        }
    }
}
