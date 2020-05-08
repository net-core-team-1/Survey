using AutoMapper;
using Survey.Identity.Contracts;
using Survey.Identity.Domain.Authentication.Commands;
using Survey.Identity.Domain.Features.Commands;
using Survey.Identity.Domain.Users.Commands;
using Survey.Indentity.Domain.Roles.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Survey.Identity.API.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //users 
            CreateMap<UserRegistrationRequest, RegisterUserCommand>();
            CreateMap<EditUserInfoRequest, EditUserInfoCommand>();
            CreateMap<ChangeEmailRequest, ChangeEmailCommand>();

            //authentication 
            CreateMap<SignInRequest, SignInCommand>();
            CreateMap<SignOutRequest, SignOutCommand>();
            CreateMap<ChangePasswordRequest, ChangePasswordCommand>();

            //Roles 
            CreateMap<CreateRoleRequest, CreateRoleCommand>();


            CreateMap<CreateRoleRequest, CreateRoleCommand>();
            CreateMap<EditRoleRequest, EditRoleCommand>();
            CreateMap<DeactivateRoleRequest, DeactivateRoleCommand>();
            CreateMap<RemoveRoleRequest, RemoveRoleCommand>();
            CreateMap<UpdateRoleFeaturesRequest, UpdateRoleFeaturesCommand>();

            //Features
            CreateMap<CreateFeatureRequest, CreateFeatureCommand>();
            CreateMap<EditFeatureRequest, EditFeatureCommand>();
            CreateMap<DeactivateFeatureRequest, DeactivateFeatureCommand>();
            CreateMap<RemoveFeatureRequest, RemoveFeatureCommand>();

        }
    }
}
