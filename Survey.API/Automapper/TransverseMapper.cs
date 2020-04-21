using AutoMapper;
using Survey.Api.Commands.Features;
using Survey.Api.Commands.Users;
using Survey.Transverse.Contract.Features.Requests;
using Survey.Transverse.Contract.Users.Requests;

namespace Survey.Api.Automapper
{
    public class TransverseMapper : Profile
    {
        public TransverseMapper()
        {
            CreateMap<UserRegistrationRequest, RegisterUserCommand>();
            CreateMap<EditUserRequest, EditUserCommand>();
            CreateMap<EditFeatureRequest, EditFeatureCommand>();

        }
    }
}
