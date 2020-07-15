using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Entities
{
    public interface IEntityRepository
    {
        Entity FindByKey(Guid? id);
        void Insert(Entity entity);
        bool Save();
        public List<Entity> GetAll();
    }
}
