using CSharpFunctionalExtensions;
using Identity.Api.Data.Repositories.Structures;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain.Structure.Commands;
using Survey.Common.Types;
using Survey.Identity.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Structures.Commands
{
    public class EditStructureUsersCommandHandler : ICommandHandler<EditStructureUsersCommand>
    {
        private readonly IStructureRepository _structureRepository;
        private readonly IUserService _userService;
        public EditStructureUsersCommandHandler(IStructureRepository structureRepository,
            IUserService userService)
        {
            _structureRepository = structureRepository;
            _userService = userService;
        }

        public Task<Result> Handle(EditStructureUsersCommand command)
        {
            var structure = _structureRepository.FindByKey(command.StructureId);
            if (structure == null)
                throw new IdentityException("Structure not found");

            var users = _userService.FindRoleByIdsAsync(command.Users);
            if (users.Result.Count() != command.Users.Count())
                throw new IdentityException("Invalid_Users", "one or many users not found in database, make sure that users exists");

            structure.EditUsers(command.AssignedBy, command.Users);
            _structureRepository.Save();
            return Task.FromResult(Result.Success());
        }
    }
}
