using Dapper;
using Identity.Api.Contrats.Structures.Responses;
using Identity.Api.Identity.Domain.Structures.Queries;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Structures.QueryHandlers
{
    public class GetStructureByIdQueryHandler : IQueryHandler<GetStructureByIdQuery, StructureResponse>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetStructureByIdQueryHandler(QueriesConnectionString queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }
        public StructureResponse Handle(GetStructureByIdQuery query)
        {
            string sql = @"
                    Select Top 1 Id as structureId,
	                       Name,
	                       Description
                    From [Identity].[Structures]
                    where Id=@Id";

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                StructureResponse structure = connection
                        .Query<StructureResponse>(sql, new
                        {
                            Id = query.Id
                        })
                        .FirstOrDefault();

                return structure;
            }
        }
    }
}
