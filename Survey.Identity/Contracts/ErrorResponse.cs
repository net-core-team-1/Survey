﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Contracts
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
            Errors = new List<ErrorModel>();
        }
        public ErrorResponse(ErrorModel error)
        {
            Errors.Add(error);
        }

        public List<ErrorModel> Errors { get; set; }
    }
}
