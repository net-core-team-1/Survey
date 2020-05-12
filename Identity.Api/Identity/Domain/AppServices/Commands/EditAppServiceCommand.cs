using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppServices.Commands
{
    public class EditAppServiceCommand : ICommand
    {
        public Guid AppServiceId { get; }
        public string Name { get; }
        public string Description { get; }

        public EditAppServiceCommand(Guid appServiceId, string name, string description)
        {
            AppServiceId = appServiceId;
            Name = name;
            Description = description;
        }
    }
}
