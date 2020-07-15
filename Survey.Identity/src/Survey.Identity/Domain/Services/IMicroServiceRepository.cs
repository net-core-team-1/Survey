﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Services
{
    public interface IMicroServiceRepository
    {
        MicroService FindByKey(Guid id);
        void Insert(MicroService microService);
        List<MicroService> GetAll();
        bool Save();
    }
}