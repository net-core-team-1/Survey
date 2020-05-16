using Dapper;
using Identity.Api.Contrat.Features.Responses;
using Identity.Api.Contrats.Features.Responses;
using Identity.Api.Identity.Domain.Features.Queries;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Features.QueriesHandlers
{
    public class GetListFeaturesByRoleIdQueryHandler : IQueryHandler<GetListFeaturesByRoleIdQuery, FeaturesListResponse>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetListFeaturesByRoleIdQueryHandler(QueriesConnectionString queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }
        public FeaturesListResponse Handle(GetListFeaturesByRoleIdQuery query)
        {
            string sql = @"
                    Select  f.Id as featureId,
	                        f.Label,
                            f.Description,
                            f.Controller as ControllerName,
                            f.ControllerActionName,
                            f.Action,
                            f.ServiceId
                    From [Identity].[Features] f
                    Inner join [Identity].[RoleFeatures] rf
                        On f.Id = rf.FeatureId
                    WHERE rf.RoleId = @RoleId";

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                var result = connection.Query<FeatureResponse>(sql, new
                {
                    RoleId = query.RoleId
                }).ToList();
                return new FeaturesListResponse(result);
            }
        }
    }
}
