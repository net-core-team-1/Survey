using Castle.DynamicProxy.Generators.Emitters;
using Dapper;
using Identity.Api.Contrats.Users.Responses.UserInfo;
using Identity.Api.Contrats.Users.Responses.UserPermissionsInfo;
using Identity.Api.Identity.Domain.Users.Queries;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Users.QuerieHandlers
{
    public class GetUserPermissionsInfoByIdQueryHandler : IQueryHandler<GetUserPermissionsInfoByIdQuery, UserPermissionInfoResponse>
    {
        private readonly QueriesConnectionString _connectionString;
        public GetUserPermissionsInfoByIdQueryHandler(QueriesConnectionString queriesConnectionString)
        {
            _connectionString = queriesConnectionString;
        }
        public UserPermissionInfoResponse Handle(GetUserPermissionsInfoByIdQuery query)
        {
            string userQuery = @"
                    Select TOP 1 UserName    
                    From [Identity].[USERS]
                    where Id=@Id";

            string userRolesQuery = @"
                    Select  r.ServiceId,
                            ur.RoleId,
	                        r.Name
                    From [Identity].[UserRoles] ur
                    INNER JOIN [Identity].[Roles] r ON ur.RoleId = r.Id 
                    where ur.UserId=@Id";

            string roleFeaturesQuery = @"
                    Select  rf.RoleId,
                            f.Id as featureId,
	                        f.Label
                    From [Identity].[Features] f
                    Inner join [Identity].[RoleFeatures] rf
                        On f.Id = rf.FeatureId
                    WHERE rf.RoleId in @RoleIds";

            string userStructuresQuery = @"select S.Id ,S.Name
                                            from [Identity].[StructureUsers] SU
                                             INNER JOIN [Identity].[Structures] S ON S.Id = SU.StructureId
                                            where SU.UserId = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString.Value))
            {
                var response = new UserPermissionInfoResponse();
                response.UserId = query.UserId;
                response.Name = connection.Query<string>(userQuery, new
                {
                    Id = query.UserId
                }).FirstOrDefault();

                response.Roles = connection.Query<UserRolesInfoResponse>(userRolesQuery, new
                {
                    Id = query.UserId
                }).ToList();
               
                var roleFeatures = connection.Query(roleFeaturesQuery, new
                {
                    RoleIds = response.Roles.Select(c => c.RoleId).Distinct().ToList()
                }).Select(s => new Tuple<Guid, Guid, string>(s.RoleId, s.featureId, s.Label)).ToList();

                foreach (var role in response.Roles)
                    role.Features = roleFeatures.Where(x => x.Item1 == role.RoleId)
                                                .ToDictionary(x => (Guid)x.Item2, x => (string)x.Item3);

                response.Structures = connection.Query(userStructuresQuery, new
                {
                    Id = query.UserId
                }).ToDictionary(x => (Guid)x.Id, x => (string)x.Name);


                return response;
            }
        }
    }
}
