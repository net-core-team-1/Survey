using AutoMapper;
using Survey.Api.Commands;
using Survey.Transverse.Contract.Users.Requests;

namespace Survey.Transverse.API.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationRequest, RegisterUserCommand>();
        }
    }
}
