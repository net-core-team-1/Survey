using Survey.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Api.Services
{
    public interface IUserDtoService
    {
        Task AddUserDtoAsync(UserDto user);
        Task<IEnumerable<UserDto>> BrowseAsync();
    }
}
