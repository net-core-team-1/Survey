using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Entities
{
    public class EntityLevel
    {
        #region Fields 
        public Guid Id { get; set; }
        public virtual NameDesc NameDesciption { get; set; }
        public virtual DeleteInfo DeleteInfo { get; private set; }
        public virtual CreateInfo CreateInfo { get; private set; }

        public byte[] Timestamp { get; private set; }

        public virtual Guid? ParentId { get; private set; }
        public virtual EntityLevel Parent { get; private set; }


        #endregion

        #region Ctor
        protected EntityLevel()
        {

        }
        public EntityLevel(NameDesc nameDescription, CreateInfo createInfo,EntityLevel parent)
        {
            Id = Guid.NewGuid();
            NameDesciption = nameDescription;
            CreateInfo = createInfo;
            Parent = parent;
            DeleteInfo = DeleteInfo.Create().Value;

        }
        #endregion

        #region Methods 
        public void EditInfo(NameDesc nameDescription,EntityLevel parent)
        {
            if (NameDesciption != nameDescription)
                NameDesciption = NameDesciption;
            Parent = parent;
        }

        public void Delete(DeleteInfo deleteInfo)
        {
            if (DeleteInfo.Deleted)
                throw new SurveyException("entity_already_unregistred");
            DeleteInfo = deleteInfo;
        }
        #endregion 

    }
}
