using Survey.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Api.Domain.Repositories
{
    public interface IUserDtoRepository
    {
        Task<UserDto> GetAsync(Guid id);
        Task<IEnumerable<UserDto>> BrowseAsync();
        Task AddAsync(UserDto user);
    }
}
