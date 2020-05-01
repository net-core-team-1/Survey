using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Identity.Domain
{
    public class CreateInfo : ValueObject
    {
        public DateTime? CreatedOn { get; private set; }
        public Guid? CreatedBy { get; private set; }

        protected CreateInfo()
        {

        }
        private CreateInfo(Guid? createdBy)
        {
            CreatedOn = DateTime.Now;
            CreatedBy = createdBy;
        }
        public static Result<CreateInfo> Create(Guid? createdBy = null)
        {
            return Result.Success(new CreateInfo(createdBy));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CreatedOn;
            yield return CreatedBy;
        }

    }
}
