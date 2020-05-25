using MongoDB.Driver;
using System.Threading.Tasks;
using System.Linq;

namespace Survey.MongoDb
{
    public class MongoSeeder : IDatabaseSeeder
    {
        protected readonly IMongoDatabase _database;

        public MongoSeeder(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task SeedAsync()
        {
            var collectionCusrsor = await _database.ListCollectionsAsync();
            var collection = await collectionCusrsor.ToListAsync();
            if (collection.Any())
                return;
            await CustomSeedAsync();
        }

        protected virtual async Task CustomSeedAsync()
        {
            await Task.CompletedTask;
        }
    }
}
