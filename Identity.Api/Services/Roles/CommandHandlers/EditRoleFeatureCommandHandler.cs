﻿using CSharpFunctionalExtensions;
using Identity.Api.Data;
using Identity.Api.Data.Repositories.Features;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain.Features;
using Identity.Api.Identity.Domain.RoleFeature;
using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Services.Roles;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Roles.CommandHandlers
{
    public class EditRoleFeatureCommandHandler : ICommandHandler<EditRoleFeatureCommand>
    {
        private readonly IRoleService _roleService;
        private readonly IFeatureRepository _featureRepository;
   
        public EditRoleFeatureCommandHandler(IRoleService roleService,
                IFeatureRepository featureRepository )
        {
            _roleService = roleService;
            _featureRepository = featureRepository;
        }
        public async Task<Result> Handle(EditRoleFeatureCommand command)
        {
            var role = _roleService.FindRoleById(command.RoleId).Result;
            if (role == null)
                throw new IdentityException("ROLE_NOT_FOUND", "Role not found in database");
           
            var features = _featureRepository.FindBy(x => 
                                    command.Features.Distinct().Contains(x.Id)).ToList();
            if (features.Count() != command.Features.Count())
                throw new IdentityException("FEATURE_NOT_FOUND", "One or more features not found in database," +
                    "make sur that the features exists in database");
            
            role.EditFeatures(command.AssignedBy, features);

            await _roleService.UpdateAsync(role);
            
            return await Task.FromResult(Result.Ok());
        }
    }
}
