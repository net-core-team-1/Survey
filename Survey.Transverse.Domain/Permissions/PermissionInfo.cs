using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Permissions
{
    public class PermissionInfo : ValueObject
    {

        public String Label { get; private set; }
        public String Description { get; private set; }

        protected PermissionInfo()
        {

        }
        private PermissionInfo(string label, string description)
        {
            Label = label;
            Description = description;
        }
        public static Result<PermissionInfo> Create(string label, string description)
        {
            if (string.IsNullOrWhiteSpace(label) || string.IsNullOrWhiteSpace(description))
                return Result.Failure<PermissionInfo>("Label/Description should not be empty");

            label = label.Trim();
            description = description.Trim();

            if (description.Length > 250 || label.Length > 50 || label.Length < 5)
                return Result.Failure<PermissionInfo>("Label/Description length not correct");

            return Result.Success(new PermissionInfo(label, description));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Label;
            yield return Description;
        }
    }
}
