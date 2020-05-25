using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Entities
{
    public interface IEntityRepository
    {
        Entity FindByKey(Guid? id);
        Entity FindByCode(string code);
        void Insert(Entity entity);
        bool IsCodeUsed(string code);
        bool Save();
    }
}
