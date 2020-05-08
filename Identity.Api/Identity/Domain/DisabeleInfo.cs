using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Identity.Domain
{
    public class DisabeleInfo : ValueObject
    {
        public DateTime? DisabledOn { get; set; }
        public Guid? DisabledBy { get; set; }
        public bool? Disabled { get; set; }

        protected DisabeleInfo()
        {

        }
        private DisabeleInfo(bool? disabled, Guid? disabledBy)
        {
            Disabled = disabled;
            DisabledBy = disabledBy;
            if (disabledBy != null)
                DisabledOn = DateTime.Now;
        }
        public static Result<DisabeleInfo> Create(bool? disabled = null, Guid? disabledBy = null)
        {
            if (Guid.Empty == disabledBy)
                return Result.Failure<DisabeleInfo>("should not be empty");

            return Result.Success(new DisabeleInfo(disabled, disabledBy));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DisabledOn;
            yield return DisabledBy;
            yield return Disabled;
        }

    }
}
