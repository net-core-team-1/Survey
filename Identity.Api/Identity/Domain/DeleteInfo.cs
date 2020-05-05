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
        private DeleteInfo(bool? deleted, Guid? deletedBy, string deleteReason)
        {
            Deleted = deleted;
            if (deleted != null && deleted.Value)
                DeletedOn = DateTime.Now.ToUniversalTime();
            DeletedBy = deletedBy;
            DeleteReason = deleteReason;
        }
        public static Result<DeleteInfo> Create(bool? deleted = null, Guid? deletedBy = null, string deleteReason = null)
        {
            if (string.IsNullOrWhiteSpace(deleteReason) && deletedBy != null)
                return Result.Failure<DeleteInfo>("Delete reason should be supplied");

            return Result.Success(new DeleteInfo(deleted, deletedBy, deleteReason));
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
