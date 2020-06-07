using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders
{
    public class RootSeederResult
    {
        public SeederTypeName Type { get; set; }
        public string Value { get; set; }
    }
    public enum SeederTypeName : int
    {
        Structure = 0,
        RootUser = 1,
        AppService = 2,
        AdminRole = 3,
        MaleCivilityId = 4,
        FemaleCivility = 5
    }
}
