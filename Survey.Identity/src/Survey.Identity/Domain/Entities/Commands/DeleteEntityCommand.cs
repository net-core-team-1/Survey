using Survey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Entities.Commands
{
    public class DeleteEntityCommand : ICommand
    {
        public Guid Id { get; }
        public Guid By { get; set; }
        public string Reason { get; set; }

        public DeleteEntityCommand(Guid id, Guid by,string reason)
        {
            Id = id;
            By = by;
            Reason = reason;
        }
    }
}
