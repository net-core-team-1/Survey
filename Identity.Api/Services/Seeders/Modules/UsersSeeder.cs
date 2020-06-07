using Identity.Api.Data.Repositories.Structures;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.Civilities;
using Identity.Api.Identity.Domain.Users;
using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Utils.ResultValidator;
using Survey.Identity.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders.Modules
{
    public class UsersSeeder : IUserSeeder
    {
        private readonly IUserService _userService;
        private readonly IStructureRepository _structureRepository;
        public UsersSeeder(IUserService userService, IStructureRepository structureRepository)
        {
            _userService = userService;
            _structureRepository = structureRepository;

        }

        public async Task SeedAsync(Dictionary<SeederTypeName, RootSeederResult> rootValues)
        {
            Guid structureId = Guid.Parse(rootValues[SeederTypeName.Structure].Value);
            Guid adminRoleId = Guid.Parse(rootValues[SeederTypeName.AdminRole].Value);
            int civilityId = int.Parse(rootValues[SeederTypeName.MaleCivilityId].Value);
            var permission = new List<Guid>() { adminRoleId };
            RegisterUserCommand command =
                new RegisterUserCommand("Administrator", "Admin", "Admun", "Admin@mail.com", "Identity123#Admin", civilityId, permission, structureId);

            var fullNameResult = FullName.Create(command.FirstName, command.LastName).Validate();
            var civility = new Civility(command.CivilityId);
            var passwordResult = UserPassword.Create(command.Password).Validate();
            var userNameResult = UserName.Create(command.UserName).Validate();
            var emailResult = UserEmail.Create(command.Email).Validate();
            var structure = _structureRepository.FindByKey(command.StructureId);
            if (structure == null)
                throw new IdentityException("Structure not found", "No structure found in database with the given key!");

            var user = _userService.FindUserByUserNameAsync(command.UserName).Result;
            if (user != null)
                await Task.FromResult<RootSeederResult>(new RootSeederResult() { Type = SeederTypeName.RootUser, Value = user.Id.ToString() });

            var rootUser = new AppUser(userNameResult.Value, fullNameResult.Value,
                emailResult.Value, command.Permissions, civility, structure);
            var result = await _userService.RegisterNewAsync(rootUser, passwordResult.Value);
            result.Validate();

            await Task.FromResult<RootSeederResult>(new RootSeederResult() { Type = SeederTypeName.RootUser, Value = rootUser.Id.ToString() });
        }
    }
}
