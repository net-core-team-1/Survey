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
    public class GetStructureUsersQueryHandler : IQueryHandler<GetStructureUsersQuery, StructureUserResponse>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetStructureUsersQueryHandler(QueriesConnectionString queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }
        public StructureUserResponse Handle(GetStructureUsersQuery query)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                var structure = connection.Query<StructureUserResponse>(
                          "Select TOP 1 Id as StructureId, Name,Description from [Identity].[Structures] Where Id=@Id",
                           new { Id = query.StructureId }).FirstOrDefault();

                structure.Users = connection.Query<Guid>(
                          "select UserId from [Identity].[StructureUsers] where StructureId = @Id",
                           new { Id = query.StructureId }).ToList();

                return structure;
            }
        }
    }
}
