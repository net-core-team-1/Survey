using Dapper;
using Identity.Api.Contrat.Roles.Responses;
using Identity.Api.Identity.Domain.Roles.Queries;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Roles.Queries
{
    public class GetAllRolesQueryHandler : IQueryHandler<GetAllRolesQuery, List<RoleListResponse>>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetAllRolesQueryHandler(QueriesConnectionString queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }
        public List<RoleListResponse> Handle(GetAllRolesQuery query)
        {
            string sql = @"
                    Select Id,
	                       Name,
	                       Description
                    From [Identity].[Roles]";

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                var result = connection.Query<RoleListResponse>(sql).ToList();
                return result;
            }
        }
    }
}
