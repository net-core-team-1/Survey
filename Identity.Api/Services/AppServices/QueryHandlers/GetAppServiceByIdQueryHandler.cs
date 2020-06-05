using Dapper;
using Identity.Api.Contrats.AppServices.Responses;
using Identity.Api.Identity.Domain.AppServices.Queries;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.AppServices.QueryHandlers
{
    public class GetAppServiceByIdQueryHandler : IQueryHandler<GetAppServiceByIdQuery, AppServiceResponse>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetAppServiceByIdQueryHandler(QueriesConnectionString queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }

        public AppServiceResponse Handle(GetAppServiceByIdQuery query)
        {
            string sql = @"SELECT [Id] as appServiceId " +
                        ",[Name] " +
                        ",[Description] " +
                        "FROM [Identity].[AppServices] appService " +
                        "WHERE appService.Id = @Id ";

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                AppServiceResponse response = connection
                        .Query<AppServiceResponse>(sql, new
                        {
                            Id = query.AppServiceId
                        })
                        .FirstOrDefault();

                return response;
            }
        }
    }
}
