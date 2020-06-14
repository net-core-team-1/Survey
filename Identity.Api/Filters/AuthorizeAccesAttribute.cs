using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Filters
{
    public class AuthorizeAccesAttribute : TypeFilterAttribute
    {
        public AuthorizeAccesAttribute() : base(typeof(AuthorizeAccessFilter))
        {
            
        }
    }
}
