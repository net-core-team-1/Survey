using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structures
{
    public class StructureInfo : ValueObject
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        protected StructureInfo() { }
        private StructureInfo(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static Result<StructureInfo> Create(string name, string description)
        {
            return Result.Success(new StructureInfo(name, description));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
