using CSharpFunctionalExtensions;
using System.Collections.Generic;

namespace Survey.Identity.Domain.Entities
{
    public class NameDesc : ValueObject
    {
        public string Name { get; set; }
        public string Description { get; set; }


        protected NameDesc()
        {

        }
        private NameDesc(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static Result<NameDesc> Create(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 4 || name.Length > 100)
                return Result.Failure<NameDesc>("name_is_not_valid");

            if (string.IsNullOrWhiteSpace(description) || description.Length < 5 || description.Length > 255)
                return Result.Failure<NameDesc>("name_is_not_valid");

            return Result.Success(new NameDesc(name, description));
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Description;
        }
    }
}
