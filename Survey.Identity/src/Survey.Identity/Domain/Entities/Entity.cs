using System;

namespace Survey.Identity.Domain.Entities
{
    public class Entity
    {
        #region FIELDS 
        public Guid Id { get; private set; }
        public virtual NameDesc NameDesciption { get; private set; }
        public byte[] Timestamp { get; private set; }
        public virtual DeleteInfo DeleteInfo { get; private set; }
        public virtual CreateInfo CreateInfo { get; private set; }



        #endregion

        #region Ctor
        protected Entity()
        {

        }
        public Entity(NameDesc nameDescription,  CreateInfo createInfo)
        {
            Id = Guid.NewGuid();
            NameDesciption = nameDescription;
            CreateInfo = createInfo;
            DeleteInfo = DeleteInfo.Create().Value;
        }
        #endregion

        #region Methods 
        public void EditInfo(NameDesc nameDescription)
        {
            if (NameDesciption != nameDescription)
                NameDesciption = nameDescription;

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
