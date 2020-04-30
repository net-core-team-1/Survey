using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Domain
{
    public class DisabeleInfo : ValueObject
    {
        public DateTime? DisabledOn { get; set; }
        public Guid? DisabledBy { get; set; }
        public bool Disabled { get { return DisabledOn != null; } }


        protected DisabeleInfo()
        {

        }
        private DisabeleInfo(Guid? disabledBy)
        {
            DisabledBy = disabledBy;
            if (disabledBy != null)
                DisabledOn = DateTime.Now;
        }
        public static Result<DisabeleInfo> Create(Guid? disabledBy = null)
        {
            if (Guid.Empty == disabledBy)
                return Result.Failure<DisabeleInfo>("should not be empty");

            return Result.Success(new DisabeleInfo(disabledBy));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DisabledOn;
            yield return DisabledBy;
            yield return Disabled;
        }

    }
}
