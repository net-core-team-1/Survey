using Dapper;
using Identity.Api.Contrat.Users.Responses;
using Identity.Api.Identity.Domain.Users.Queries;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Users.QuerieHandlers
{
    public sealed class GetRolesByUserIdQueryHandler : IQueryHandler<GetRolesByUserIdQuery, UserRolesResponse>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetRolesByUserIdQueryHandler(QueriesConnectionString queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }

        public UserRolesResponse Handle(GetRolesByUserIdQuery query)
        {
            string sql = @"
                    Select ur.RoleId,
	                       r.Name
                    From [Identity].[UserRoles] ur
                    INNER JOIN [Identity].[Roles] r ON ur.RoleId = r.Id 
                    where ur.UserId=@Id";


            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                var result = connection.Query(sql, new
                {
                    Id = query.UserId
                }).ToDictionary(x => (Guid)x.RoleId, x => (string)x.Name);

                return new UserRolesResponse() { Roles = result };
            }
        }
    }
}
