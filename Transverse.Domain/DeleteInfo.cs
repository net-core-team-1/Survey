using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain
{
    public class DeleteInfo : ValueObject
    {
        public Guid? DeletedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public bool Deleted { get { return DeletedOn != null; } }
        public string DeleteReason { get; private set; }

        protected DeleteInfo()
        {

        }
        private DeleteInfo(Guid? deletedBy, string deleteReason)
        {
            if (deletedBy != null)
                DeletedOn = DateTime.Now;

            DeletedBy = deletedBy;
            DeleteReason = deleteReason;
        }
        public static Result<DeleteInfo> Create(Guid? deletedBy = null, string deleteReason = null)
        {
            if (string.IsNullOrWhiteSpace(deleteReason) && deletedBy != null)
                return Result.Failure<DeleteInfo>("Delete reason should be supplied");

            return Result.Success(new DeleteInfo(deletedBy, deleteReason));
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
