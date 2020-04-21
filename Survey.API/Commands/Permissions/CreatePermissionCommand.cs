using Survey.Common.Messages;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Api.Commands.Permissions
{
    [Message("transverse")]
    public sealed class CreatePermissionCommand : ICommand
    {
        public string Label { get; }
        public string Description { get; }
        public Guid CreatedBy { get; }
        public List<Guid> Features { get; }


        public CreatePermissionCommand(string label, string description, Guid createdBy, List<Guid> features = null)
        {
            Label = label;
            Description = description;
            CreatedBy = createdBy;
            Features = features;
        }
    }
}
