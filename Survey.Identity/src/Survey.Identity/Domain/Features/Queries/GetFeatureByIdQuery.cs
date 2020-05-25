using Survey.CQRS.Commands;
using Survey.Identity.Contracts;
using System;

namespace Survey.Identity.Domain.Features.Queries
{
    public sealed class GetFeatureByIdQuery : IQuery<FeatureResponse>
    {
        public Guid Id { get;  }
        public GetFeatureByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
