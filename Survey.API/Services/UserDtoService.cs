using Survey.Api.Domain.Models;
using Survey.Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Api.Services
{
    public class UserDtoService : IUserDtoService
    {
        private readonly IUserDtoRepository _userDtoRepository;

        public UserDtoService(IUserDtoRepository userDtoRepository)
        {
            _userDtoRepository = userDtoRepository;
        }
        public async Task AddUserDtoAsync(UserDto user)
            => await _userDtoRepository.AddAsync(user);

        public async Task<IEnumerable<UserDto>> BrowseAsync()
            => await _userDtoRepository.BrowseAsync();
    }
}
