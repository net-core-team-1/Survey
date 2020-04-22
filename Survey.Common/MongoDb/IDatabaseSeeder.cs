using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Common.MongoDb
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}
