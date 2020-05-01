using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Domain.Features.Commands
{
    public sealed class EditFeatureCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Label { get; }
        public string Description { get; }

        public EditFeatureCommand(Guid id, string label, string description)
        {
            Id = id;
            Label = label;
            Description = description;
        }
    }
}
