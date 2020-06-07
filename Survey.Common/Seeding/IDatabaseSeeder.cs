using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Common.Seeding
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}
