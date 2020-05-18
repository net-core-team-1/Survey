using CSharpFunctionalExtensions;
using Identity.Api.Data.Repositories.Structures;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain.Structures;
using Identity.Api.Identity.Domain.Structures.Commands;
using Survey.Common.Types;
using Survey.Identity.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Structures.Commands
{
    public class RegisterStructureUserCommandHandler : ICommandHandler<RegisterStructureUserCommand>
    {
        private readonly IStructureRepository _structureRepository;
        private readonly IUserService _userService;
        public RegisterStructureUserCommandHandler(IStructureRepository structureRepository,
            IUserService userService)
        {
            _structureRepository = structureRepository;
            _userService = userService;
        }
        public Task<Result> Handle(RegisterStructureUserCommand command)
        {
            var structure = _structureRepository.FindByKey(command.StructureId);
            if (structure == null)
                throw new IdentityException("Structure not found");

            var users = _userService.FindUserByUserIdAsync(command.UserId);
            if (users == null)
                throw new IdentityException("Invalid_Users", "one or many users not found in database, make sure that users exists");

            structure.RegisterUser(new StructureUsers(structure.Id, users.Result.Id));
            _structureRepository.Save();
            return Task.FromResult(Result.Success());
        }
    }
}
