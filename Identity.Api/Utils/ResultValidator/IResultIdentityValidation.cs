﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Utils.ResultValidator
{
    public interface IResultIdentityValidation
    {
        void Validate(IdentityResult input);
    }
}
