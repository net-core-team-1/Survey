using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survey.MongoDb
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}
