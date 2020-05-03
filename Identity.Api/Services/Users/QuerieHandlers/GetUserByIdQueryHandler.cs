using Dapper;
using Identity.Api.Identity.Contrat.Users.Responses;
using Identity.Api.Identity.Domain.Users.Queries;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Users.QuerieHandlers
{
    public sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetUserByIdQueryHandler(QueriesConnectionString queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }

        public UserResponse Handle(GetUserByIdQuery query)
        {
            string sql = @"
                    Select Top 1 Id,
	                       FirstName,
	                       LastName,
	                       Email 
                    From [Identity].[USERS]
                    where Id=@Id";

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                UserResponse user = connection
                        .Query<UserResponse>(sql, new
                        {
                            Id = query.UserId
                        })
                        .FirstOrDefault();

                return user;
            }
        }
    }
}
