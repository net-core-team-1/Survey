using Identity.Api.Identity.Domain.Civilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Data.Repositories.Civilities
{
    public interface ICivilityRepository
    {
        List<Civility> GetAll();
        Task AddNew(Civility civility);
        void Update(Civility civility);
        bool Save();
    }
}
