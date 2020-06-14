using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Types.Types.ServiceBus;
using Identity.Api.Contrat.AppServices.Requests;
using Identity.Api.Filters;
using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Identity.Domain.AppServices.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.Common.Messages;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeAccesAttribute]
    public class AppServiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommandSender _commandSender;
        private readonly Dispatcher _dispatcher;

        public AppServiceController(IMapper mapper, ICommandSender commandSender, Dispatcher dispatcher)
        {
            _mapper = mapper;
            _commandSender = commandSender;
            _dispatcher = dispatcher;
        }

        [HttpGet("GetService")]
        public IActionResult GetService(Guid serviceId)
        {
            return Ok(_dispatcher.Dispatch(new GetAppServiceByIdQuery(serviceId)));
        }

        [HttpGet("GetServiceList")]
        public IActionResult GetAllServices()
        {
            return Ok(_dispatcher.Dispatch(new GetListAppServiceQuery()));
        }

        [HttpGet("GetDetailledServiceInfo")]
        public IActionResult GetDetailledServiceInfo(Guid serviceId)
        {
            return Ok(_dispatcher.Dispatch(new GetDetailledAppServiceQuery(serviceId)));
        }

        [HttpPost()]
        public IActionResult Register([FromBody] RegisterAppServiceRequest request)
        {
            var command = _mapper.Map<RegisterAppServiceCommand>(request);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] EditAppServiceRequest request)
        {
            var command = _mapper.Map<EditAppServiceCommand>(request);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPatch]
        public IActionResult Disable([FromBody] DisableAppServiceRequest request)
        {
            var command = _mapper.Map<DisableAppServiceCommand>(request);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Unregister([FromBody] DeleteAppServiceRequest request)
        {
            var command = _mapper.Map<DeleteAppServiceCommand>(request);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }
    }
}