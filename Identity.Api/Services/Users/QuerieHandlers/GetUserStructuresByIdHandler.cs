using Dapper;
using Identity.Api.Contrats.Users.Responses.UserStructures;
using Identity.Api.Identity.Domain.Users.Queries;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Users.QuerieHandlers
{
    public class GetUserStructuresByIdHandler : IQueryHandler<GetUserStructuresById, UserStructureResponse>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetUserStructuresByIdHandler(QueriesConnectionString queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }
        public UserStructureResponse Handle(GetUserStructuresById query)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                var response = new UserStructureResponse();
                response.Structures = connection.Query<Guid>(
                          "select UserId from [Identity].[StructureUsers] where UserId = @Id",
                           new { Id = query.UserId }).ToList();

                return response;
            }
        }
    }
}
