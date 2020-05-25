using Microsoft.EntityFrameworkCore;
using Survey.Identity.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Data.Repositories
{
    public class MicroServiceRepository : IMicroServiceRepository
    {
        private readonly SurveyIdentityContext _context;

        public MicroServiceRepository(SurveyIdentityContext context)
        {
            _context = context;
        }
        public MicroService FindByKey(Guid id)
        {
            return _context.MicroServices.FirstOrDefault(a => a.Id == id);
        }
    }
}
