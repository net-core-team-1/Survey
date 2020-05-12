using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppServices
{
    public class AppServiceInfo : ValueObject
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        protected AppServiceInfo() { }
        private AppServiceInfo(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static Result<AppServiceInfo> Create(string name, string description)
        {
            return Result.Success(new AppServiceInfo(name, description));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
