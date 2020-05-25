using Survey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Entities.Commands
{
    public class CreateEntityCommand : ICommand
    {
        public string Name { get; }
        public string Description { get; }
        public Guid? ParentId { get; }
        public Guid LevelId { get; }
        public string Code { get; }
        public Guid CreatedBy { get;  }

        public CreateEntityCommand(string name, string description,
                                    string code,
                                    Guid parentId, Guid levelId,Guid createdBy)
        {
            Name = name;
            Description = description;
            ParentId = parentId;
            LevelId = levelId;
            Code = code;
            CreatedBy = createdBy;
        }
    }
}
