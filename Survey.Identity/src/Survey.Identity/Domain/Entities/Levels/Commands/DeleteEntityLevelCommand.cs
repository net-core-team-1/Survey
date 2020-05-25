using Survey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Entities.Levels.Commands
{
    public class DeleteEntityLevelCommand:ICommand
    {
        public Guid Id { get;  }
        public Guid By { get;  }
        public string Reason { get; set; }

        public DeleteEntityLevelCommand(Guid id,string reason,Guid by)
        {
            Id = id;
            Reason = reason;
            By = by;

        }
    }
}
