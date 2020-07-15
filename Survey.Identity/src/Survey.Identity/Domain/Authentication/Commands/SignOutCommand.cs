﻿using Survey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Domain.Authentication.Commands
{
    public sealed class SignOutCommand:ICommand
    {
        public Guid Id { get;  }
        public SignOutCommand(Guid id)
        {
            Id = id;
        }
    }
}