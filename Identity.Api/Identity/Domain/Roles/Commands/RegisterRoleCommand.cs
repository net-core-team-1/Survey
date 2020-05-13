using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Commands
{
    public class RegisterRoleCommand : ICommand
    {
        public string Name { get; }
        public string Description { get; }
        public Guid CreatedBy { get; }
        public Guid AppServiceId { get; }

        public RegisterRoleCommand(string name, string description, Guid createdBy, Guid appServiceId)
        {
            Name = name;
            Description = description;
            CreatedBy = createdBy;
            AppServiceId = appServiceId;
        }
    }
}
