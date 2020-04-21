using Survey.Common.Messages;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Api.Commands.Permissions
{
    [Message("transverse")]
    public sealed class EditPermissionCommand : ICommand
    {
        public Guid Id { get; }
        public string Label { get; }
        public string Description { get; }

        public List<Guid> Features { get; }
        public bool DeleteExistingFeatures { get; }

        public EditPermissionCommand(Guid id, string label, string description, List<Guid> features = null,
                                     bool deleteExisting = false)
        {
            Id = id;
            Label = label;
            Description = description;
            DeleteExistingFeatures = deleteExisting;
            Features = features;
        }
    }
}
