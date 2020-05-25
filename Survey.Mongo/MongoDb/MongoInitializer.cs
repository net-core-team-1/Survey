using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survey.MongoDb
{
    public class MongoInitializer : IDatabaseInitializer
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IDatabaseSeeder _seeder;
        private bool _seed;
        private bool _initialized;

        public MongoInitializer(IMongoDatabase mongoDatabase,
                                IDatabaseSeeder seeder,
                                IOptions<MongoOptions> options)
        {
            _mongoDatabase = mongoDatabase;
            _seeder = seeder;
            _seed = options.Value.Seed;
        }
        public async Task InitializeAsync()
        {
            if (_initialized)
                return;

            RegisterConventions();
            _initialized = true;

            if (!_seed)
                return;

            await _seeder.SeedAsync();
        }
        private void RegisterConventions()
        {
            ConventionRegistry.Register("SurveyConventions", new MongoConvention(), x => true);

        }
    }
    public class MongoConvention : IConventionPack
    {
        public IEnumerable<IConvention> Conventions => new List<IConvention>
        {
            new IgnoreExtraElementsConvention(true),
            new EnumRepresentationConvention(MongoDB.Bson.BsonType.String),
            new CamelCaseElementNameConvention()
        };
    }
}
