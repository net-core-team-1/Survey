using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Common.MongoDb
{
    public static class Extensions
    {
        public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoOptions>(configuration.GetSection("mongo"));

            services.AddSingleton<MongoClient>(cfg =>
            {
                var options = cfg.GetService<IOptions<MongoOptions>>();
                return new MongoClient(options.Value.ConnectionString);
            });

            services.AddTransient<IMongoDatabase>(cfg =>
            {
                var options = cfg.GetService<IOptions<MongoOptions>>();
                var client = cfg.GetService<MongoClient>();
                return client.GetDatabase(options.Value.Database);
            });


            return services;
        }
    }
}
