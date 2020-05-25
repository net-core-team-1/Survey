using Survey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Entities.Levels.Commands
{
    public class AddEntityLevelCommand:ICommand
    {
        public Guid Id { get;  }
        public string Name { get;  }
        public string Description { get;  }
        public Guid CreatedBy { get;  }
        public Guid? ParentId { get; set; }

        public AddEntityLevelCommand(Guid id,string name,string description,Guid createdBy,Guid parentId)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedBy = createdBy;
            ParentId = parentId;
        }
    }
}
