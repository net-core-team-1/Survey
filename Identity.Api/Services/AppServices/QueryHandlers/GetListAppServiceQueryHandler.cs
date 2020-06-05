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
    public class GetListAppServiceQueryHandler : IQueryHandler<GetListAppServiceQuery, AppServiceListResponse>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetListAppServiceQueryHandler(QueriesConnectionString queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }

        public AppServiceListResponse Handle(GetListAppServiceQuery query)
        {
            string sql = @"SELECT [Id] as appServiceId " +
                        ",[Name] " +
                        ",[Description] " +
                        "FROM [Identity].[AppServices] appService ";

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                List<AppServiceResponse> responses = connection
                        .Query<AppServiceResponse>(sql)
                        .ToList();

                return new AppServiceListResponse(responses);
            }
        }
    }
}
