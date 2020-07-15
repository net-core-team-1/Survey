using CSharpFunctionalExtensions;
using Survey.Identity.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Services.MicroServices
{
    public interface IMicroServiceService
    {
        public MicroService FindByKey(Guid id);

        public Task<Result> Insert(string name,string description,Guid? createdBy);
    }
}
