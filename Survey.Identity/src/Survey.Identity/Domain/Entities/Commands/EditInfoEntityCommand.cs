using Survey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Entities.Commands
{
    public class EditInfoEntityCommand : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }

        public EditInfoEntityCommand(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
