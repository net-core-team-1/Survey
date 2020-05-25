using System;

namespace Survey.Identity.Domain.Entities
{
    public class Entity
    {
        #region FIELDS 
        public Guid Id { get; private set; }
        public virtual NameDesc NameDesciption { get; private set; }
        public byte[] Timestamp { get; private set; }
        public virtual FunctionalCode FuncCode { get; private set; }
        public virtual DeleteInfo DeleteInfo { get; private set; }
        public virtual CreateInfo CreateInfo { get; private set; }

        public virtual EntityLevel EntityLevel { get; private set; }
        public virtual Guid? ParentId { get; private set; }
        public virtual Entity ParentEntity { get; private set; }


        #endregion

        #region Ctor
        protected Entity()
        {

        }
        public Entity(NameDesc nameDescription, FunctionalCode code,
                     EntityLevel entityLevel, CreateInfo createInfo,
                     Entity parent = null)
        {
            Id = Guid.NewGuid();
            NameDesciption = nameDescription;
            FuncCode = code;
            CreateInfo = createInfo;
            DeleteInfo = DeleteInfo.Create().Value;
            SetHierarchy(parent, entityLevel);
        }
        #endregion

        #region Methods 
        public void EditInfo(NameDesc nameDescription, FunctionalCode funcCode, Entity parent, EntityLevel entityLevel)
        {
            if (NameDesciption != nameDescription)
                NameDesciption = nameDescription;

            if (FuncCode != funcCode)
                FuncCode = funcCode;
            SetHierarchy(parent, entityLevel);
        }
        public void Delete(DeleteInfo deleteInfo)
        {
            if (DeleteInfo.Deleted)
                throw new SurveyException("entity_already_unregistred");
            DeleteInfo = deleteInfo;
        }

        private void SetHierarchy(Entity parent, EntityLevel entityLevel)
        {
            if (parent != null)
                if (parent.EntityLevel.Id != entityLevel.Parent.Id)
                    throw new SurveyException("invalid_parent");
            if (parent == null && entityLevel.Parent != null)
                throw new SurveyException("invalid_parent");
            ParentEntity = parent;
            EntityLevel = entityLevel;

        }
        #endregion
    }
}
