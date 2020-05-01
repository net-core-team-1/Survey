using AutoMapper;
using Identity.Api.Identity.Contrat.Users.Requests;
using Identity.Api.Identity.Domain.Users.Commands;
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
        }
    }
}
