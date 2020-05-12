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
    public class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, RoleResponse>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetRoleByIdQueryHandler(QueriesConnectionString queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }
        public RoleResponse Handle(GetRoleByIdQuery query)
        {
            string sql = @"
                    Select Id,
	                       Name,
	                       Description
                    From [Identity].[Roles]
                    WHERE [Identity].[Roles].Id=@Id";

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                RoleResponse user = connection
                        .Query<RoleResponse>(sql, new
                        {
                            Id = query.Id
                        })
                        .FirstOrDefault();

                return user;
            }
        }
    }
}
