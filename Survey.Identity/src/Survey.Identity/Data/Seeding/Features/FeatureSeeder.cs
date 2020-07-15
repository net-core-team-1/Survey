using CSharpFunctionalExtensions;
using Survey.Identity.Domain.Features.Commands;
using Survey.Identity.Domain.Services;
using Survey.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Data.Seeding.Features
{
    public class FeatureSeeder : IFeatureSeeder
    {
        private readonly IMicroServiceRepository _serviceRepository;
        private readonly DispatcherAsync _dispatcher;

        public FeatureSeeder(IMicroServiceRepository serviceRepository, DispatcherAsync dispatcher)
        {
            _serviceRepository = serviceRepository;
            _dispatcher = dispatcher;
        }
        public async Task<Result> SeedAsync()
        {
            var service = _serviceRepository.GetAll().FirstOrDefault();

            if (service != null)
            {
                //entities
                var command1 = new CreateFeatureCommand("CreateEntity", "CreateEntity", "CreateEntity", "Entities", "Post", null, service.Id);
                var command2 = new CreateFeatureCommand("EditEntityInfo", "EditEntityInfo", "EditInfo", "Entities", "Post", null, service.Id);
                var command3 = new CreateFeatureCommand("DeleteEntity", "DeleteEntity", "DeleteEntity", "Entities", "Post", null, service.Id);
                //Roles
                var command4 = new CreateFeatureCommand("CreateRole", "CreateRole", "CreateRole", "Roles", "Post", null, service.Id);
                var command5 = new CreateFeatureCommand("EditRole", "EditRole", "EditRole", "Roles", "Post", null, service.Id);
                var command6 = new CreateFeatureCommand("UpdateFeaturesInRole", "UpdateFeaturesInRole", "UpdateFeaturesInRole", "Roles", "Post", null, service.Id);
                var command7 = new CreateFeatureCommand("DeactivateRole", "DeactivateRole", "DeactivateRole", "Roles", "Post", null, service.Id);
                var command8 = new CreateFeatureCommand("ActivateRole", "ActivateRole", "ActivateRole", "Roles", "Post", null, service.Id);
                var command9 = new CreateFeatureCommand("RemoveRole", "RemoveRole", "RemoveRole", "Roles", "Post", null, service.Id);

                //users 
                var command10 = new CreateFeatureCommand("RegisterUser", "RegisterUser", "RegisterUser", "Users", "Post", null, service.Id);
                var command11 = new CreateFeatureCommand("EditeUserInfo", "EditeUserInfo", "EditeUserInfo", "Users", "Post", null, service.Id);
                var command12 = new CreateFeatureCommand("ChangeUserEmail", "ChangeUserEmail", "ChangeUserEmail", "Users", "Post", null, service.Id);
                var command13 = new CreateFeatureCommand("UnregisterUser", "UnregisterUser", "UnregisterUser", "Users", "Post", null, service.Id);

                //features
                var command14 = new CreateFeatureCommand("CreateFeature", "CreateFeature", "CreateFeature", "Features", "Post", null, service.Id);
                var command15 = new CreateFeatureCommand("EditFeatureInfo", "EditFeatureInfo", "EditFeatureInfo", "Features", "Post", null, service.Id);
                var command16 = new CreateFeatureCommand("DeactivateFeature", "DeactivateFeature", "DeactivateFeature", "Features", "Post", null, service.Id);
                var command17 = new CreateFeatureCommand("ActivateFeature", "ActivateFeature", "ActivateFeature", "Features", "Post", null, service.Id);
                var command18 = new CreateFeatureCommand("RemoveFeature", "RemoveFeature", "RemoveFeature", "Features", "Post", null, service.Id);

                //result
                var result1 = await _dispatcher.Dispatch(command1);
                var result2 = await _dispatcher.Dispatch(command2);
                var result3 = await _dispatcher.Dispatch(command3);
                var result4 = await _dispatcher.Dispatch(command4);
                var result5 = await _dispatcher.Dispatch(command5);
                var result6 = await _dispatcher.Dispatch(command6);
                var result7 = await _dispatcher.Dispatch(command7);
                var result8 = await _dispatcher.Dispatch(command8);
                var result9 = await _dispatcher.Dispatch(command9);
                var result10 = await _dispatcher.Dispatch(command10);
                var result11 = await _dispatcher.Dispatch(command11);
                var result12 = await _dispatcher.Dispatch(command12);
                var result13 = await _dispatcher.Dispatch(command13);
                var result14 = await _dispatcher.Dispatch(command14);
                var result15 = await _dispatcher.Dispatch(command15);
                var result16 = await _dispatcher.Dispatch(command16);
                var result17 = await _dispatcher.Dispatch(command17);
                var result18 = await _dispatcher.Dispatch(command18);
                var result = Result.Combine(result1, result2, result3, result4, result5, result6, result7, result8, result9, result10,
                                            result11, result12, result13, result14, result15, result16, result17, result18);
                return result;

            }
            return await Task<Result>.FromResult(Result.Failure($"error_seeading_roles"));
        }
    }
}
