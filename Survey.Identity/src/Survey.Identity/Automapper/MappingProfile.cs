using AutoMapper;
using Survey.Identity.Contracts;
using Survey.Identity.Contracts.EntityLevels.Requests;
using Survey.Identity.Domain.Authentication.Commands;
using Survey.Identity.Domain.Entities.Commands;
using Survey.Identity.Domain.Features.Commands;
using Survey.Identity.Domain.Users.Commands;
using Survey.Indentity.Domain.Roles.Commands;

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
            CreateMap<UnregisterRequest, UnregisterUserCommand>();

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
            CreateMap<ActivateRoleRequest, ActivateRoleCommand>();

            //Features
            CreateMap<CreateFeatureRequest, CreateFeatureCommand>();
            CreateMap<EditFeatureRequest, EditFeatureCommand>();
            CreateMap<DeactivateFeatureRequest, DeactivateFeatureCommand>();
            CreateMap<RemoveFeatureRequest, RemoveFeatureCommand>();
            CreateMap<ActivateFeatureRequest, ActivateFeatureCommand>();

            //Entities 
            CreateMap<CreateEntityRequest, CreateEntityCommand>();
            CreateMap<EditInfoEntityRequest, EditInfoEntityCommand>();
            CreateMap<DeleteEntityRequest, DeleteEntityCommand>();



        }
    }
}
