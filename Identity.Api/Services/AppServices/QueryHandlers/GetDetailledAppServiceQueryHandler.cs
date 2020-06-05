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
    public class GetDetailledAppServiceQueryHandler : IQueryHandler<GetDetailledAppServiceQuery, AppServiceDetailledResponse>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetDetailledAppServiceQueryHandler(QueriesConnectionString queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }

        public AppServiceDetailledResponse Handle(GetDetailledAppServiceQuery query)
        {
            string appServiceQuery = @"SELECT [Id] as appServiceId " +
                                     ",[Name] " +
                                     ",[Description] " +
                                     "FROM [Identity].[AppServices] appService " +
                                     "WHERE appService.Id = @Id ";

            string rolesQuery = @"SELECT [Id]" +
                                    " ,[Name]" +
                                    " ,[StructureId]" +
                                    "  FROM [Identity].[Roles] roles" +
                                    "  WHERE roles.[ServiceId] = @Id";

            string featureQuery = @"SELECT [Id] " +
                                    ",[Label] " +
                                    "FROM [Identity].[Features] feature " +
                                    "WHERE feature.ServiceId = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                AppServiceResponse response = connection
                        .Query<AppServiceResponse>(appServiceQuery, new
                        {
                            Id = query.AppServiceId
                        })
                        .FirstOrDefault();

                var serviceRoles = connection.Query(rolesQuery, new
                {
                    Id = query.AppServiceId
                }).ToDictionary(x => (Guid)x.Id, x => (string)x.Name);

                var serviceFeatures = connection.Query(featureQuery, new
                {
                    Id = query.AppServiceId
                }).ToDictionary(x => (Guid)x.Id, x => (string)x.Label);

                return new AppServiceDetailledResponse()
                {
                    AppServiceId = response.AppServiceId,
                    Description = response.Description,
                    Name = response.Name,
                    Features = serviceFeatures,
                    Roles = serviceRoles,
                };
            }
        }
    }
}
