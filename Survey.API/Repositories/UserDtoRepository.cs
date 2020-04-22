using MongoDB.Driver;
using Survey.Api.Domain.Models;
using Survey.Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace Survey.Api.Repositories
{
    public class UserDtoRepository : IUserDtoRepository
    {
        private readonly IMongoDatabase _dataBase;

        public UserDtoRepository(IMongoDatabase dataBase)
        {
            _dataBase = dataBase;
        }
        public async Task AddAsync(UserDto user)
              => await Collection.InsertOneAsync(user);


        public async Task<IEnumerable<UserDto>> BrowseAsync()
            => await Collection.AsQueryable().ToListAsync();

        public async Task<UserDto> GetAsync(Guid id)
              => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        private IMongoCollection<UserDto> Collection
               => _dataBase.GetCollection<UserDto>("users");
    }
}
