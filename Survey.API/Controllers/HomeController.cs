﻿using Microsoft.AspNetCore.Mvc;

namespace Survey.Transverse.API.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Survey API Service is online");
    }
}