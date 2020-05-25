using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Survey.Identity.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Controllers
{
    public class BaseController : Controller
    {

        public BaseController()
        {
        }

        protected new IActionResult Ok()
        {
            return base.Ok(Envelope.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(Envelope.Error(errorMessage));
        }

        protected IActionResult FromResult(Result result)
        {

            return  result.IsSuccess ? Ok(result) : Error(result.Error);
        }
        protected IActionResult NotFound(string errorMessage)
        {
            return NotFound(Envelope.Error(errorMessage));
        }
    }
}
