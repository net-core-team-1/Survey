using Identity.Api.Contrats.Structures.Responses;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structures.Queries
{
    public class GetStructureByIdQuery :IQuery<StructureResponse>
    {
        public Guid Id { get; }

        public GetStructureByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
