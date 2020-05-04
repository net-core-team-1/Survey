using Dapper;
using Identity.Api.Identity.Contrat.Features.Responses;
using Identity.Api.Identity.Domain.Features.Queries;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Features.QueriesHandlers
{
    public class GetFeatureQueryHandler : IQueryHandler<GetFeatureQuery, FeatureResponse>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetFeatureQueryHandler(QueriesConnectionString queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }
        public FeatureResponse Handle(GetFeatureQuery query)
        {
            string sql = @"
                    Select  f.Id as featureId,
	                        f.Label,
                            f.Description,
                            f.Controller as ControllerName,
                            f.ControllerActionName,
                            f.Action
                    From [Identity].[Features] f
                    Where f.Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                FeatureResponse result = connection.Query<FeatureResponse>(sql, new
                {
                    Id = query.FeatureId
                }).FirstOrDefault();

                return result;
            }
        }
    }
}
