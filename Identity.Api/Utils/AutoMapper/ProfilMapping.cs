using AutoMapper;
using Identity.Api.Identity.Contrat.Features.Requests;
using Identity.Api.Identity.Contrat.Roles.Requests;
using Identity.Api.Identity.Contrat.Users.Requests;
using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Domain.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Utils.AutoMapper
{
    public class ProfilMapping : Profile
    {
        public ProfilMapping()
        {
            CreateMap<RegisterUserRequest, RegisterUserCommand>();
            CreateMap<UnregisterUserRequest, UnregisterUserCommand>();
            CreateMap<EditUserRequest, EditUserCommand>();

            CreateMap<EditUserRolesRequest, EditUserRolesCommad>();

            CreateMap<RegisterFeatureRequest, RegisterFeatureCommand>();
            CreateMap<UnregisterFeatureRequest, UnRegisterFeatureCommand>();
            CreateMap<DisableFeatureRequest, DisableFeatureCommand>();
            CreateMap<EditFeatureRequest, EditFeatureCommand>();

            CreateMap<RegisterRoleRequest, RegisterRoleCommand>();
            CreateMap<EditRoleRequest, EditRoleCommand>();
            CreateMap<DisableRoleRequest, DisableRoleCommand>();
            CreateMap<UnregisterRoleRequest, UnregisterRoleCommand>();


        }
    }
}
