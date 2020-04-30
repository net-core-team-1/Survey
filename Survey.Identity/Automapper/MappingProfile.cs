using AutoMapper;
using Survey.Identity.Contracts;
using Survey.Identity.Domain.Users.Commands;

namespace Survey.Identity.API.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationRequest, RegisterUserCommand>();
            CreateMap<EditUserInfoRequest,     EditUserInfoCommand>();
        }
    }
}
