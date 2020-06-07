using CSharpFunctionalExtensions;
using Identity.Api.Data.Repositories.Features;
using Identity.Api.Data.Repositories.Services;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.Features;
using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Utils.ResultValidator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders.Modules
{
    public class FeaturesSeeder : IFeatureSeeder
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IAppServiceRepository _appServiceRepository;

        public FeaturesSeeder(IFeatureRepository featureRepository,
             IAppServiceRepository appServiceRepository)
        {
            _featureRepository = featureRepository;
            _appServiceRepository = appServiceRepository;
        }

        public async Task SeedAsync(Dictionary<SeederTypeName, RootSeederResult> rootValues)
        {
            Guid rootUserId = Guid.Parse(rootValues[SeederTypeName.RootUser].Value);
            Guid rootAppServiceId = Guid.Parse(rootValues[SeederTypeName.AppService].Value);
            List<RegisterFeatureCommand> features = new List<RegisterFeatureCommand>()
            {
                new RegisterFeatureCommand("AppServiceController_GetService_Get","","AppServiceController","GetService","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("AppServiceController_GetAllServices_Get","","AppServiceController","GetAllServices","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("AppServiceController_GetDetailledServiceInfo_Get","","AppServiceController","GetDetailledServiceInfo","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("AppServiceController_Register_Post","","AppServiceController","Register","Post",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("AppServiceController_GetDetailledServiceInfo_Edit","","AppServiceController","Edit","Put",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("AppServiceController_Disable_Patch","","AppServiceController","Disable","Patch",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("AppServiceController_Unregister_Delete","","AppServiceController","Unregister","Delete",rootUserId,rootAppServiceId),

                new RegisterFeatureCommand("FeatureController_GetFeature_Get","","FeatureController","GetFeature","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("FeatureController_GetFeatureList_Get","","FeatureController","GetFeatureList","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("FeatureController_Register_Post","","FeatureController","Register","Post",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("FeatureController_Edit_Put","","FeatureController","Edit","Put",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("FeatureController_Disable_Patch","","FeatureController","Disable","Patch",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("FeatureController_Unregister_Delete","","FeatureController","Unregister","Delete",rootUserId,rootAppServiceId),

                new RegisterFeatureCommand("FeaturesAppServiceController_GetFeatureListByService_Get","","FeaturesAppServiceController","GetFeatureListByService","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("FeaturesAppServiceController_Edit_Put","","FeaturesAppServiceController","Edit","Put",rootUserId,rootAppServiceId),

                new RegisterFeatureCommand("RoleFeaturesController_GetRoleFeature_Get","","RoleFeaturesController","GetRoleFeature","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("RoleFeaturesController_Edit_Get","","RoleFeaturesController","Edit","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("RoleFeaturesController_AssignFeature_Post","","RoleFeaturesController","AssignFeature","Post",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("RoleFeaturesController_RemoveFeature_Put","","RoleFeaturesController","RemoveFeature","Put",rootUserId,rootAppServiceId),

                new RegisterFeatureCommand("RolesController_GetRoleById_Get","","RolesController","GetRoleById","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("RolesController_GetAllRoles_Get","","RolesController","GetAllRoles","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("RolesController_Register_Post","","RolesController","Register","Post",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("RolesController_Edit_Put","","RolesController","Edit","Put",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("RolesController_Disable_Patch","","RolesController","Disable","Patch",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("RolesController_Unregister_Delete","","RolesController","Unregister","Delete",rootUserId,rootAppServiceId),

                new RegisterFeatureCommand("StructureController_GetRoleById_Get","","StructureController","GetStructure","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("StructureController_GetAllRoles_Get","","StructureController","GetAllStructures","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("StructureController_Register_Post","","StructureController","Register","Post",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("StructureController_Edit_Put","","StructureController","Edit","Put",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("StructureController_Disable_Patch","","StructureController","Disable","Patch",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("StructureController_Unregister_Delete","","StructureController","Unregister","Delete",rootUserId,rootAppServiceId),

                new RegisterFeatureCommand("StructureUsersController_GetRoleById_Get","","StructureController","GetUserStructures","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("StructureUsersController_GetAllRoles_Get","","StructureController","GetStructureUsers","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("StructureUsersController_Register_Post","","StructureController","Register","Post",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("StructureUsersController_Edit_Put","","StructureController","Edit","Put",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("StructureUsersController_Unregister_Delete","","StructureController","Unregister","Delete",rootUserId,rootAppServiceId),

                new RegisterFeatureCommand("UserRolesController_GetUserRoles_Get","","UserRolesController","GetUserRoles","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("UserRolesController_EditRoles_Post","","UserRolesController","EditRoles","Post",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("UserRolesController_AssignUserRole_Put","","UserRolesController","AssignUserRole","Put",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("UserRolesController_RemoveUserRole_Delete","","UserRolesController","RemoveUserRole","Delete",rootUserId,rootAppServiceId),

                new RegisterFeatureCommand("UsersController_GetUser_Get","","UsersController","GetUser","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("UsersController_GetUserInfo_Get","","UsersController","GetUserInfo","Get",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("UsersController_Register_Post","","UsersController","Register","Post",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("UsersController_UnregisterUser_Delete","","UsersController","UnregisterUser","Delete",rootUserId,rootAppServiceId),
                new RegisterFeatureCommand("UsersController_EditUser_Patch","","UsersController","EditUser","Patch",rootUserId,rootAppServiceId),

            };

            foreach (var item in features)
            {
                await Seed(item);
            }
        }

        private async Task Seed(RegisterFeatureCommand command)
        {
            var count = _featureRepository
                            .FindBy(x => x.FeatureInfo.Controller == command.ControllerName
                                    && x.FeatureInfo.ControllerActionName == command.ControllerActionName
                                    && x.ServiceId == command.AppServiceId
                                    && x.FeatureInfo.Label == command.Label).Count();
            if (count != 0)
                return;

            var service = _appServiceRepository.FindByKey(command.AppServiceId);
            if (service == null)
                throw new IdentityException("Service_not_found", "Service not found in database with the given Id");

            var createFeatureResult = FeatureInfo.Create(command.Label, command.Description, command.ControllerName,
                command.ControllerActionName, command.Action).Validate();
            var createInfoResult = CreateInfo.Create(command.CreatedBy);
            var feature = new Feature(createFeatureResult.Value, createInfoResult.Value, service);
            _featureRepository.Insert(feature);
            try
            {
                _featureRepository.Save();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
}
