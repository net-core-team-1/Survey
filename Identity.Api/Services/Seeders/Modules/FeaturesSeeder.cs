using Identity.Api.Data.Repositories.Features;
using Identity.Api.Data.Repositories.Services;
using Identity.Api.Identity.Domain.Features.Commands;
using Survey.Common.Messages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders.Modules
{
    public class FeaturesSeeder : IFeatureSeeder
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IAppServiceRepository _appServiceRepository;
        private readonly Dispatcher _dispatcher;

        public FeaturesSeeder(IFeatureRepository featureRepository,
             IAppServiceRepository appServiceRepository,
             Dispatcher dispatcher)
        {
            _featureRepository = featureRepository;
            _appServiceRepository = appServiceRepository;
            _dispatcher = dispatcher;
        }

        public async Task SeedAsync(Dictionary<SeederTypeName, RootSeederResult> rootValues)
        {
            Guid rootUserId = Guid.Parse(rootValues[SeederTypeName.RootUser].Value);
            Guid rootAppServiceId = Guid.Parse(rootValues[SeederTypeName.AppService].Value);
            List<RegisterFeatureCommand> features = new List<RegisterFeatureCommand>()
            {
                new RegisterFeatureCommand("AppService_GetService_Get","","AppService","GetService","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("AppService_GetAllServices_Get","","AppService","GetAllServices","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("AppService_GetDetailledServiceInfo_Get","","AppService","GetDetailledServiceInfo","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("AppService_Register_Post","","AppService","Register","Post",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("AppService_GetDetailledServiceInfo_Edit","","AppService","Edit","Put",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("AppService_Disable_Patch","","AppService","Disable","Patch",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("AppService_Unregister_Delete","","AppService","Unregister","Delete",rootUserId,rootAppServiceId),

                new RegisterFeatureCommand("Feature_GetFeature_Get","","Feature","GetFeature","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Feature_GetFeatureList_Get","","Feature","GetFeatureList","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Feature_Register_Post","","Feature","Register","Post",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Feature_Edit_Put","","Feature","Edit","Put",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Feature_Disable_Patch","","Feature","Disable","Patch",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Feature_Unregister_Delete","","Feature","Unregister","Delete",rootUserId,rootAppServiceId),

                new RegisterFeatureCommand("FeaturesAppService_GetFeatureListByService_Get","","FeaturesAppService","GetFeatureListByService","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("FeaturesAppService_Edit_Put","","FeaturesAppService","Edit","Put",rootUserId,rootAppServiceId),

                new RegisterFeatureCommand("RoleFeatures_GetRoleFeature_Get","","RoleFeatures","GetRoleFeature","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("RoleFeatures_Edit_Get","","RoleFeatures","Edit","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("RoleFeatures_AssignFeature_Post","","RoleFeatures","AssignFeature","Post",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("RoleFeatures_RemoveFeature_Put","","RoleFeatures","RemoveFeature","Put",rootUserId,rootAppServiceId),

                new RegisterFeatureCommand("Roles_GetRoleById_Get","","Roles","GetRoleById","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Roles_GetAllRoles_Get","","Roles","GetAllRoles","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Roles_Register_Post","","Roles","Register","Post",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Roles_Edit_Put","","Roles","Edit","Put",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Roles_Disable_Patch","","Roles","Disable","Patch",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Roles_Unregister_Delete","","Roles","Unregister","Delete",rootUserId,rootAppServiceId),

                new RegisterFeatureCommand("Structure_GetRoleById_Get","","Structure","GetStructure","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Structure_GetAllRoles_Get","","Structure","GetAllStructures","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Structure_Register_Post","","Structure","Register","Post",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Structure_Edit_Put","","Structure","Edit","Put",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Structure_Disable_Patch","","Structure","Disable","Patch",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Structure_Unregister_Delete","","Structure","Unregister","Delete",rootUserId,rootAppServiceId),

                new RegisterFeatureCommand("StructureUsers_GetRoleById_Get","","Structure","GetUserStructures","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("StructureUsers_GetAllRoles_Get","","Structure","GetStructureUsers","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("StructureUsers_Register_Post","","Structure","Register","Post",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("StructureUsers_Edit_Put","","Structure","Edit","Put",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("StructureUsers_Unregister_Delete","","Structure","Unregister","Delete",rootUserId,rootAppServiceId),

                new RegisterFeatureCommand("UserRoles_GetUserRoles_Get","","UserRoles","GetUserRoles","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("UserRoles_EditRoles_Post","","UserRoles","EditRoles","Post",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("UserRoles_AssignUserRole_Put","","UserRoles","AssignUserRole","Put",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("UserRoles_RemoveUserRole_Delete","","UserRoles","RemoveUserRole","Delete",rootUserId,rootAppServiceId),

                new RegisterFeatureCommand("Users_GetUser_Get","","Users","GetUser","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Users_GetUserInfo_Get","","Users","GetUserInfo","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Users_Register_Post","","Users","Register","Post",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Users_UnregisterUser_Delete","","Users","UnregisterUser","Delete",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("Users_EditUser_Patch","","Users","EditUser","Patch",rootUserId,rootAppServiceId),

            };

            foreach (var item in features)
            {
                await Seed(item);
            }
        }

        private async Task Seed(RegisterFeatureCommand command)
        {
            _dispatcher.Dispatch(command);
        }
    }
}
