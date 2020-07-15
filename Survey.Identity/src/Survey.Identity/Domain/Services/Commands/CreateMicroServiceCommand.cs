using Survey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Services.Commands
{
    public class CreateMicroServiceCommand:ICommand
    {
        public string Name { get;  }
        public string Description { get;  }
        public Guid? CreatedBy { get;  }
        public CreateMicroServiceCommand(string name,string description,Guid? createdBy=null)
        {
            Name = name;
            Description = description;
            CreatedBy = createdBy;
        }
    }
}
