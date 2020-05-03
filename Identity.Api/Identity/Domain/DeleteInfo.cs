using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Api.Identity.Domain
{
    public class DeleteInfo : ValueObject
    {
        public Guid? DeletedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public bool? Deleted { get; private set; }
        public string DeleteReason { get; private set; }

        protected DeleteInfo()
        {

        }
        private DeleteInfo(Guid? deletedBy, string deleteReason, DateTime? deletedOn, bool deleted)
        {
            Deleted = deleted;
            DeletedOn = deletedOn;
            if (deletedOn == null)
                DeletedOn = DateTime.Now;

            DeletedBy = deletedBy;
            DeleteReason = deleteReason;
        }
        public static Result<DeleteInfo> Create(Guid? deletedBy = null, string deleteReason = null, DateTime? deletedOn = null, bool deleted = false)
        {
            if (string.IsNullOrWhiteSpace(deleteReason) && deletedBy != null)
                return Result.Failure<DeleteInfo>("Delete reason should be supplied");

            return Result.Success(new DeleteInfo(deletedBy, deleteReason, deletedOn, deleted));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DeletedBy;
            yield return DeletedOn;
            yield return Deleted;
            yield return DeleteReason;
        }
    }
}
