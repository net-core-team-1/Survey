﻿using Survey.Common.Types;
using System;
using System.Collections.Generic;

namespace Survey.Indentity.Domain.Roles.Commands
{
    public sealed class UpdateRoleFeaturesCommand : ICommand
    {
        public Guid Id { get; }
        public List<Guid> Features { get; }
        public bool DeleteExisting { get; set; }


        public UpdateRoleFeaturesCommand(Guid id, List<Guid> features = null, bool deleteExisting = false)
        {
            Id = id;
            DeleteExisting = deleteExisting;
            Features = features;
        }
    }
}
