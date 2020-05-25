﻿using System;
using Survey.CQRS.Commands;
using Survey.CQRS.Messages;

namespace Survey.Api.Commands.Users
{

    [Message("transverse")]
    public sealed class UnregisterUserCommand : ICommand
    {
        public Guid Id { get; }
        public string Reason { get; }
        public Guid By { get; set; }

        public UnregisterUserCommand(Guid id, Guid by, string reason)
        {
            Id = id;
            Reason = reason;
            By = by;
        }
    }
}
