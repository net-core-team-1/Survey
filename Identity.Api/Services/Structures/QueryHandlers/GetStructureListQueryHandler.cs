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
    public class GetStructureListQueryHandler : IQueryHandler<GetStructureListQuery, StructureListResponse>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetStructureListQueryHandler(QueriesConnectionString queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }
        public StructureListResponse Handle(GetStructureListQuery query)
        {
            string sql = @"
                    Select Id as structureId,
	                       Name,
	                       Description
                    From [Identity].[Structures]";
                   
            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                List<StructureResponse> structures = connection
                        .Query<StructureResponse>(sql)
                        .ToList();

                return new StructureListResponse(structures);
            }
        }
    }
}
