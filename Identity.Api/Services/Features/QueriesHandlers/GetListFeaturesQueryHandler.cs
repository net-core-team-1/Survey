﻿using Dapper;
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
    public class GetListFeaturesQueryHandler : IQueryHandler<GetListFeaturesQuery, FeaturesListResponse>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetListFeaturesQueryHandler(QueriesConnectionString queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }
        public FeaturesListResponse Handle(GetListFeaturesQuery query)
        {
            string sql = @"
                    Select  f.Id as featureId,
	                        f.Label,
                            f.Description,
                            f.Controller as ControllerName,
                            f.ControllerActionName,
                            f.Action,
                            f.ServiceId
                    From [Identity].[Features] f";

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                var result = connection.Query<FeatureResponse>(sql).ToList();
                return new FeaturesListResponse(result);
            }
        }
    }
}
