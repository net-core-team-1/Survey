using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Domain
{
    public class DisableInfo : ValueObject
    {
        public DateTime? DisabledOn { get; set; }
        public Guid? DisabledBy { get; set; }
        public bool Disabled { get { return DisabledOn != null; } }


        protected DisableInfo()
        {

        }
        private DisableInfo(Guid? disabledBy,DateTime? disabledOn=null)
        {
            DisabledBy = disabledBy;
            if (disabledBy != null && disabledBy != null)
                DisabledOn = DateTime.Now;
            else DisabledOn = disabledOn;
        }
        public static Result<DisableInfo> Create(Guid? disabledBy = null)
        {
            if (Guid.Empty == disabledBy)
                return Result.Failure<DisableInfo>("disabledby_should_have_value");

            return Result.Success(new DisableInfo(disabledBy));
        }

        public void EmptyObject()
        {
            DisabledOn = null;
            DisabledBy = null;
            
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DisabledOn;
            yield return DisabledBy;
            yield return Disabled;
        }

    }
}
