﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{
    public class SignInRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
